
var vShaderSource = 
`precision mediump float;
    attribute vec3 vertPos;
    attribute vec3 u_color;
    attribute vec2 _textCoord;
    varying vec3 color;
    varying vec2 texCoord;
    uniform mat4 view;
    uniform mat4 projection;
    uniform mat4 world;
    void main()
    {
      color = u_color;
      texCoord = _textCoord;
      gl_Position = projection*view * world*vec4(vertPos,1.0);
    }
`

var fShaderSource = [
    'void main()',
    '{',
    '  gl_FragColor = vec4(0,1,0,1);',
    '}'
].join('\n');


var fShaderUniformSource = 
`
   precision mediump float;
   varying vec3 color;
   varying vec2 texCoord;
   uniform float textureWeight;
   uniform sampler2D Texture;
    void main()
    {
      gl_FragColor = mix(vec4(color,1.0),texture2D(Texture,texCoord),textureWeight);
    }
`


var fShaderUniformTexturesSource = 
`
   precision mediump float;
   varying vec2 texCoord;
   uniform float textureWeight;
   uniform sampler2D Texture;
   uniform sampler2D Texture1;
    void main()
    {
      gl_FragColor = mix(texture2D(Texture,texCoord),texture2D(Texture,texCoord),textureWeight);
    }
`


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


var start = function(){

    var canvas = document.getElementById("test");
    var gl = canvas.getContext('webgl');

    if(!gl){
        console.log("error!");
    }
   
    SetDefaultSettings(gl);
   // gl.disable(gl.CULL_FACE);
    //gl.frontFace(gl.CCW);
	 //gl.cullFace(gl.BACK);

    var vertexShader =  CreateShader(gl,gl.VERTEX_SHADER,vShaderSource); 


    var fragmentShader =  CreateShader(gl,gl.FRAGMENT_SHADER,fShaderUniformSource);
   
   var cubeCoords = GetCubeCoordinates();
   var cubeVertexPosBuffer = gl.createBuffer();
   gl.bindBuffer(gl.ARRAY_BUFFER,cubeVertexPosBuffer);
   gl.bufferData(gl.ARRAY_BUFFER,cubeCoords,gl.STATIC_DRAW);
   
   var cubeIndexCoords = GetCubeIndeces();
   var cubeIndexBuffer =  gl.createBuffer();
   gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER,cubeIndexBuffer);
   gl.bufferData(gl.ELEMENT_ARRAY_BUFFER,cubeIndexCoords,gl.STATIC_DRAW);
   
   var texture = gl.createTexture();
   gl.bindTexture(gl.TEXTURE_2D,texture);

   
   gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.CLAMP_TO_EDGE);
   gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.CLAMP_TO_EDGE);
   gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
   gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 
   gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('crate'));

  //  gl.bindTexture(gl.TEXTURE_2D,null);

    var program = CreateProgram(gl,vertexShader,fragmentShader);
    gl.useProgram(program); 
   
     var pos_attr = gl.getAttribLocation(program,"vertPos");
     gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,0);
      
     var color_attr = gl.getAttribLocation(program,"u_color");
     gl.vertexAttribPointer(color_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);
      
     var text_attr = gl.getAttribLocation(program,"_textCoord");
     gl.vertexAttribPointer(text_attr,2,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,6*Float32Array.BYTES_PER_ELEMENT);

     var textureWeight = gl.getUniformLocation(program,'textureWeight');
     gl.uniform1f(textureWeight,0.5);
    
       
     gl.enableVertexAttribArray(pos_attr);
     gl.enableVertexAttribArray(color_attr); 
     gl.enableVertexAttribArray(text_attr); 
    
    
     var view_matr = gl.getUniformLocation(program,'view');
     var proj_matr = gl.getUniformLocation(program,'projection');
     var world_matr = gl.getUniformLocation(program,'world');

     var viewmat4 = GetViewMatrix([0,0,-10],[0,0,0],[0,1,0]);
     var projectionmat4 = GetPerspectiveMatrix(toRadians(45),canvas.width / canvas.clientHeight,0.1,1000.0);
     var worldm4 = MultiplayMatrix(GetRotationMatrixX(40),GetRotationMatrixY(40),4,4);
     
     gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
     gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
     gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);

    gl.bindTexture(gl.TEXTURE_2D,texture);   
    gl.activeTexture(gl.TEXTURE0);
    // gl.clear(gl.DEPTH_BUFFER_BIT | gl.COLOR_BUFFER_BIT);
     gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
     
     var textWeight = 0.5;
     var addEvent = document.addEventListener ? function(target,type,action){
      if(target){
          target.addEventListener(type,action,false);
      }
  } : function(target,type,action){
      if(target){
          target.attachEvent('on' + type,action,false);
      }
  }
  
  addEvent(document,'keydown',function(e){
      e = e || window.event;
      var key = e.which || e.keyCode;
      if(key==38){
         textWeight += 0.1;
         textWeight = Math.min(textWeight,1.0);
         SetDefaultSettings(gl);
         gl.uniform1f(textureWeight,textWeight);
         gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
      }
      else if(key==40){
         textWeight -= 0.1;
         textWeight = Math.max(textWeight,0.0);
          SetDefaultSettings(gl);
          gl.uniform1f(textureWeight,textWeight);
         gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
      }
  });
  
};

var start_textures = function(){

   var canvas = document.getElementById("test");
   var gl = canvas.getContext('webgl');

   if(!gl){
       console.log("error!");
   }
  
  SetDefaultSettings(gl);

   var vertexShader =  CreateShader(gl,gl.VERTEX_SHADER,vShaderSource); 
   var fragmentShader =  CreateShader(gl,gl.FRAGMENT_SHADER,fShaderUniformSource);
  
  var cubeCoords = GetCubeCoordinates();
  var cubeVertexPosBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ARRAY_BUFFER,cubeVertexPosBuffer);
  gl.bufferData(gl.ARRAY_BUFFER,cubeCoords,gl.STATIC_DRAW);
  
  var cubeIndexCoords = GetCubeIndeces();
  var cubeIndexBuffer =  gl.createBuffer();
  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER,cubeIndexBuffer);
  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER,cubeIndexCoords,gl.STATIC_DRAW);
  
  var texture = gl.createTexture();
  gl.bindTexture(gl.TEXTURE_2D,texture);

  
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('crate'));

 //  gl.bindTexture(gl.TEXTURE_2D,null);

   var program = CreateProgram(gl,vertexShader,fragmentShader);
   gl.useProgram(program); 
  
    var pos_attr = gl.getAttribLocation(program,"vertPos");
    gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,0);
     
    var color_attr = gl.getAttribLocation(program,"u_color");
    gl.vertexAttribPointer(color_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);
     
    var text_attr = gl.getAttribLocation(program,"_textCoord");
    gl.vertexAttribPointer(text_attr,2,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,6*Float32Array.BYTES_PER_ELEMENT);

    var textureWeight = gl.getUniformLocation(program,'textureWeight');
    gl.uniform1f(textureWeight,0.5);
   
      
    gl.enableVertexAttribArray(pos_attr);
    gl.enableVertexAttribArray(color_attr); 
    gl.enableVertexAttribArray(text_attr); 
   
   
    var view_matr = gl.getUniformLocation(program,'view');
    var proj_matr = gl.getUniformLocation(program,'projection');
    var world_matr = gl.getUniformLocation(program,'world');

    var viewmat4 = GetViewMatrix([0,0,-10],[0,0,0],[0,1,0]);
    var projectionmat4 = GetPerspectiveMatrix(toRadians(45),canvas.width / canvas.clientHeight,0.1,1000.0);
    var worldm4 = MultiplayMatrix(GetRotationMatrixX(40),GetRotationMatrixY(40),4,4);
    
    gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
    gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
    gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);

   gl.bindTexture(gl.TEXTURE_2D,texture);   
   gl.activeTexture(gl.TEXTURE0);
   // gl.clear(gl.DEPTH_BUFFER_BIT | gl.COLOR_BUFFER_BIT);
    gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
    
    var textWeight = 0.5;
    var addEvent = document.addEventListener ? function(target,type,action){
     if(target){
         target.addEventListener(type,action,false);
     }
 } : function(target,type,action){
     if(target){
         target.attachEvent('on' + type,action,false);
     }
 }
 
 addEvent(document,'keydown',function(e){
     e = e || window.event;
     var key = e.which || e.keyCode;
     if(key==38){
        textWeight += 0.1;
        textWeight = Math.min(textWeight,1.0);
       SetDefaultSettings(gl);
        gl.uniform1f(textureWeight,textWeight);
        gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
     }
     else if(key==40){
        textWeight -= 0.1;
        textWeight = Math.max(textWeight,0.0);
         SetDefaultSettings(gl);
         gl.uniform1f(textureWeight,textWeight);
        gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
     }
 });
 
};


