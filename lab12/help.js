function toRadians (angle) {
    return angle * (Math.PI / 180);
  }
  
  function GetIdentity(){
     return new Float32Array([
        1,0,0,0,
        0,1,0,0,
        0,0,1,0,
        0,0,0,1
     ]);
  }
  
  //только вектор из 3 элементов
  function Normalize(v,value){
     if(value == 0)
         return [0,0,0];
  
     return [v[0]*value,v[1]*value,v[2]*value];
  }
  
  function CrossProduct(v1,v2,value,normalize){
     var res = [
        v1[1]*v2[2] - v1[2]*v2[1],
        v1[2]*v2[0] - v1[0]*v2[2],
        v1[0]*v2[1] - v1[1]*v2[0],
     ]
     if(normalize){
       Normalize(res,value);
     }
     return res;
  }
  
  //по сути реализует статичную камеру
  // да-да не учитываем,что viewer может совпадать с LookingPoint
  function GetViewMatrix(viewer,lookingPoint,pointingUp){
  
     //считаем расстояние от нас
    var z0 = viewer[0] - lookingPoint[0];
    var z1 = viewer[1] - lookingPoint[1];
    var z2 = viewer[2] - lookingPoint[2];
     
    var len = Math.hypot(z0,z1,z2); // нормализуем
     z0 *= 1/len;
     z1 *= 1/len;
     z2 *= 1/len;
    
   var x = CrossProduct(pointingUp,[z0,z1,z2],1/len,true);
   var y = CrossProduct([z0,z1,z2],x,0,false);
   len =  Math.hypot(y[0], y[1], y[2]);
   var y = Normalize(y,len);
    
   return new Float32Array([ x[0], y[0], z0 ,0, 
                             x[1], y[1] , z1, 0,
                             x[2], y[2], z2, 0,
                             -(x[0]*viewer[0]+x[1]*viewer[1]+x[2]*viewer[2]),
                             -(y[0]*viewer[0]+y[1]*viewer[1]+y[2]*viewer[2]), 
                             -(z0*viewer[0]+z1*viewer[1]+z2*viewer[2]),
                              1
                          ]);
  }
  
 
  
  function GetRotationMatrixX(angle){
     angle = toRadians(angle);
     var cos = Math.cos(angle);
     var sin = Math.sin(angle);
     return new Float32Array([
        1,0,0,0,
        0,cos,sin,0,
        0,-sin,cos,0,
        0,0,0,1
     ]);
  }
  
  function GetRotationMatrixY(angle){
     angle = toRadians(angle);
     var cos = Math.cos(angle);
     var sin = Math.sin(angle);
     return new Float32Array([
        cos,0,-sin,0,
        0,1,0,0,
        sin,0,cos,0,
        0,0,0,1
     ]);
  }
  
  
  function GetRotationMatrixZ(angle){
     angle = toRadians(angle);
     var cos = Math.cos(angle);
     var sin = Math.sin(angle);
     return new Float32Array([
        cos,sin,0,0,
        -sin,cos,0,0,
        0,0,1,0,
        0,0,0,1
     ]);
  }
  
  function GetTranslateMatrixXYZ(tx,ty,tz){
   return new Float32Array([
      1,0,0,0,
      0,1,0,0,
      0,0,1,0,
      tx,ty,tz,1
   ]);
}

function MultiplayMatrix(m1,m2,row,col){
     var res = new Float32Array(row*col);
     for (let i = 0; i < row; i++) {
        for (let j = 0; j < col; j++) {
            let sum = 0;
            for (let k = 0; k < col; k++)
                sum += m1[i * col + k] * m2[k * col + j];
            res[i * col + j] = sum;
        }
    }
    return res;
  }
  
  
  function GetPerspectiveMatrix(fov,aspect,nearDist,farDist){
  
     var res = new Float32Array(16);
     var uh = 1.0/Math.tan(fov/2);
     res[0] = uh / aspect;
     res[1] = 0;res[2] = 0;res[3] = 0;res[4] = 0;
     res[5] = uh;res[6] = 0;res[7] = 0;res[8] = 0;
     res[9] = 0;res[11] = -1;res[12] = 0;res[13] = 0;
     res[15] = 0;
  
     var fd = 1/(nearDist - farDist);
     res[10] = (farDist+nearDist)*fd;
     res[14] = 2*farDist*nearDist*fd;
     return res;
  }
  
 
 function CreateShader(gl,type,shaderSource){
   var shader = gl.createShader(type);
   gl.shaderSource(shader,shaderSource);
 
   gl.compileShader(shader);
   
   if(!gl.getShaderParameter(shader,gl.COMPILE_STATUS)){
    console.log('ERROR compiling shader');
    console.log(gl.getShaderInfoLog(shader));
 } 
 
  return shader;
 
 }
 
 
 function CreateProgram(gl,vertexShader,fragmentShader){
    var program = gl.createProgram();
    gl.attachShader(program,vertexShader);
    gl.attachShader(program,fragmentShader);
    gl.linkProgram(program);
 
    if(!gl.getProgramParameter(program, gl.LINK_STATUS)){
       console.log('ERROR compiling program');
       console.log(gl.getProgramInfoLog(program));
    }
 
    gl.validateProgram(program);
     if (!gl.getProgramParameter(program, gl.VALIDATE_STATUS)) {
         console.error('ERROR validating program!', gl.getProgramInfoLog(program));
         return null;}
 
    return program;
   }
 
 
 
 function GetCubeCoordinates(){
   return new Float32Array([
    //top            color           texture
    -1.0,1.0,-1.0,   1.0,0.0,0.0, 0.0,0.0,
    -1.0,1.0,1.0,   0.0,1.0,0.0,  0.0,1.0, 
    1.0,1.0,1.0,   0.0,0.0,1.0,   1.0,1.0,
    1.0,1.0,-1.0,   1.0,1.0,0.0,  1.0,0.0,
    
    //left
    -1.0,1.0,1.0,   1.0,0.0,0.0,   0.0,0.0,
    -1.0,-1.0,1.0,   0.0,1.0,0.0,  1.0,0.0,
    -1.0,-1.0,-1.0,   0.0,0.0,1.0, 1.0,1.0,
    -1.0,1.0,-1.0,   1.0,1.0,0.0,  0.0,1.0,
 
    //right
    1.0,1.0,1.0,  1.0,0.0,0.0,    1.0,1.0,
    1.0,-1.0,1.0,   0.0,1.0,0.0,   0.0,1.0,
    1.0,-1.0,-1.0,   0.0,0.0,1.0,  0.0,0.0,
    1.0,1.0,-1.0,   1.0,1.0,0.0,   1.0,0.0,
    
    //front
    1.0,1.0,1.0,   1.0,0.0,0.0,   1.0,1.0,
    1.0,-1.0,1.0,   0.0,1.0,0.0,  1.0,0.0,
    -1.0,-1.0,1.0,   0.0,0.0,1.0, 0.0,0.0,
    -1.0,1.0,1.0,   1.0,1.0,0.0,  0.0,1.0,
    
    //back
    1.0,1.0,-1.0,   1.0,0.0,0.0, 0.0, 0.0,
    1.0,-1.0,-1.0,   0.0,1.0,0.0, 0.0, 1.0,
    -1.0,-1.0,-1.0,   0.0,0.0,1.0, 1.0, 1.0,
    -1.0,1.0,-1.0,   1.0,1.0,0.0,  1.0, 0.0,
 
    //bottom
    -1.0,-1.0,-1.0,   1.0,0.0,0.0, 1.0, 1.0,
    -1.0,-1.0,1.0,   0.0,1.0,0.0,  1.0, 0.0,
    1.0,-1.0,1.0,   0.0,0.0,1.0,   0.0, 0.0,
    1.0,-1.0,-1.0,   1.0,1.0,0.0,  0.0, 1.0
   ]);
 }
 
 function GetCubeIndeces(){
    return new Uint16Array([
       //top
       0,1,2,
       0,2,3,
 
       //left
       5,4,6,
       6,4,7,
 
       //right
       8,9,10,
       8,10,11,
 
       //front
       13,12,14,
       15,14,12,
 
       //back
       16,17,18,
       16,18,19,
       
       //bottom
       21,20,22,
       22,20,23
    ]);
 }
 
 
 function SetDefaultSettings(gl){
    gl.clearColor(0.7,0.7,0.7,1.0);
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
    gl.enable(gl.DEPTH_TEST);
 }
 
 function GetTetrahedronCoordinates()
 {
   return new Float32Array([
    //base            color      
  //0
    -1.0,-1.0,1.0,   1.0,0.0,0.0, 
  //1  
    0.0,1.0,1.0,   0.0,1.0,0.0, 
  //2  
    1.0,-1.0,1.0,   0.0,0.0,1.0,  
    
    //left
  //3 
    -1.0,-1.0,1.0,   1.0,0.0,0.0,
  //4 
    0.0,1.0,1.0,   0.0,1.0,0.0,
  //5  
    0.0,0.0,-1.0,   1.0,1.0,1.0,
    
 
    //right
  //6 
    1.0,-1.0,1.0, 0.0,0.0,1.0,
  //7  
    0.0,0.0,-1.0,   1.0,1.0,1.0,
  //8  
    0.0,1.0,1.0,   0.0,1.0,0.0,
    
    
    //front
  //9  
    -1.0,-1.0,1.0,   1.0,0.0,0.0,
  //10  
    0.0,0.0,-1.0,   1.0,1.0,1.0,
  //11  
    1.0,-1.0,1.0,   0.0,0.0,1.0,
      
   ])
 }

 function GetTetrahedronIndeces(){
   return new Uint16Array([
      
      //base
      0,1,2,
      
      //right
      3,4,5,

      //left
      6,7,8,

      //back
      9, 10,11
   ]);
}