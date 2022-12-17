
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


var VertexObjShader = 
`   precision mediump float;
    attribute vec3 vertPos;
    attribute vec2 _textCoord;
    varying vec2 texCoord;
    uniform mat4 view;
    uniform mat4 projection;
    uniform mat4 world;
  
    void main()
    { 
     
      texCoord = _textCoord;
      gl_Position = projection*view * world*vec4(vertPos,1.0);
    }
`

var FragmentObjShader = 
`
   precision mediump float;
   varying vec2 texCoord;
   uniform float textureWeight;
   uniform sampler2D Texture;
    void main()
    {
      gl_FragColor = texture2D(Texture,texCoord);
    }
`

function GetTransformMatrix(x,y,z){
  return new Float32Array([
    1,0,0,0,
    0,1,0,0,
    0,0,1,0,
    x,y,z,1
 ]);
}

class Object {

  constructor(scale_param,x,y,z) {
    this.scale = scale_param;
    this.x = x;
    this.y = y;
    this.z = z;
  }

}


var start = async function(){

  var canvas = document.getElementById("test");
  var gl = canvas.getContext('webgl');
  
  if(!gl){
    console.log("error!");
  }
   
  var tmp = await parseObjFile('knife_lowpoly.obj');
  console.log(tmp);
  SetDefaultSettings(gl);
  
  var vertexShader =  CreateShader(gl,gl.VERTEX_SHADER,VertexObjShader); 

  var fragmentShader =  CreateShader(gl,gl.FRAGMENT_SHADER,FragmentObjShader);
     
  var cubeVertexPosBuffer = gl.createBuffer();
  gl.bindBuffer(gl.ARRAY_BUFFER,cubeVertexPosBuffer);
  gl.bufferData(gl.ARRAY_BUFFER,new Float32Array(tmp),gl.DYNAMIC_DRAW);
   
  var texture = gl.createTexture();
  gl.bindTexture(gl.TEXTURE_2D,texture);

  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.REPEAT);
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.REPEAT);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('crate'));

 
  var program = CreateProgram(gl,vertexShader,fragmentShader);
  gl.useProgram(program); 
   
  var pos_attr = gl.getAttribLocation(program,"vertPos");
      
  var text_attr = gl.getAttribLocation(program,"_textCoord");
  
  gl.enableVertexAttribArray(text_attr); 
  var rotateAngle = MultiplayMatrix(GetRotationMatrixX(90),GetRotationMatrixY(40),4,4);

  var transformData = await parseObjFile('cable_drum_low.obj');
    
  console.log(transformData);

  var transformBuffer = gl.createBuffer();

  gl.bindBuffer(gl.ARRAY_BUFFER, transformBuffer);
  gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(transformData), gl.DYNAMIC_DRAW);
   
  var main_texture = gl.createTexture();
  gl.bindTexture(gl.TEXTURE_2D,main_texture);
 
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 
  gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('main'));

   
  var viewmat4 = GetViewMatrix([0,0,-9],[0,0,0],[0,1,0]);
  var projectionmat4 = GetPerspectiveMatrix(toRadians(45),canvas.width / canvas.clientHeight,0.1,900.0);
  var view_matr = gl.getUniformLocation(program,'view');
  var proj_matr = gl.getUniformLocation(program,'projection');
  var world_matr = gl.getUniformLocation(program,'world');
  
  gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
  gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);
    

  let stepZ = 0;
  count = 3;
   
  stepY = 0;
  stepZ = 0;

  const scale_param = 0.06; // *вынести в класс
  const rotation_speed = 20; // *вынести в класс
  rotateAngle = MultiplayMatrix(GetRotationMatrixZ(90),GetRotationMatrixY(90),4,4);
  var rotateAngle_main = MultiplayMatrix(GetRotationMatrixX(40),GetRotationMatrixY(40),4,4);
  stepY = 0;
  stepZ = 0;
  const scale = [0.06,0.1,0.01,0.03,0.06]; // *вынести в класс (параметров scale double)
  var rotation = 0;
   




  // *внести изменения после рефакторинга
  const frame = () => {

    //MUST HAVE прикрутить камеру 
    /* 
    для чего:
    1)подвязать кнопки
    2)Прокинуть аргументы arg - массив arg[0] =x , arg[1] = y , arg[2] = z в видовую матрицу 
    
    Видовая матрица:
    var viewmat4 = GetViewMatrix([arg[0],arg[1],arg[2]],[0,0,0],[0,1,0]);

    3)Передать новую видовую матрицу в gpu 
    gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
    
    */

    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
     
    gl.disableVertexAttribArray(pos_attr);
     
    gl.bindBuffer(gl.ARRAY_BUFFER, transformBuffer);
    gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,0);
    gl.enableVertexAttribArray(pos_attr);
    rotateAngle_main =  MultiplayMatrix(GetRotationMatrixY(rotation_speed*Math.PI/180),rotateAngle_main,4,4);
    var main_m4 = MultiplayMatrix(GetScaleMatrix(scale_param/2,scale_param/2,scale_param/2),rotateAngle_main,4,4);
   
    gl.bindTexture(gl.TEXTURE_2D,main_texture);
        
    gl.activeTexture(gl.TEXTURE0);
    gl.vertexAttribPointer(text_attr,2,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);
    gl.uniformMatrix4fv(world_matr,gl.FALSE,main_m4);
     
    for(let i = 0;i<transformData.length/8;i+=3){
      gl.drawArrays(gl.TRIANGLES, i,3);
    } 

  
    //рисуем второстепенные объекты
    gl.disableVertexAttribArray(pos_attr);
    gl.bindBuffer(gl.ARRAY_BUFFER,cubeVertexPosBuffer);
    gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,0);
    gl.enableVertexAttribArray(pos_attr);
    gl.bindTexture(gl.TEXTURE_2D,texture);   
    gl.activeTexture(gl.TEXTURE0);
    gl.vertexAttribPointer(text_attr,2,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);

    for(var i = -5;i<=5;i+=2.5){
      rotateAngle = MultiplayMatrix(GetRotationMatrixX(rotation_speed*Math.PI/180),rotateAngle,4,4);
      // stepZ += rotation_speed*Math.PI/180;
      var x = 2*Math.cos(i+0.1*rotation*Math.PI/(180));
      var z = 2*Math.sin(i+0.1*rotation*Math.PI/(180));
      var  worldm4 = GetTransformMatrix(x,0,z);
     
      worldm4 = MultiplayMatrix(rotateAngle,worldm4,4,4);
      worldm4 = MultiplayMatrix(GetScaleMatrix(scale[rotation % 5],scale[rotation % 5],scale[rotation % 5]),worldm4,4,4);
      gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
      rotation++;
      for(let i = 0;i<tmp.length/8;i+=3){
        gl.drawArrays(gl.TRIANGLES, i,3);
      } 
    }    
    requestAnimationFrame(frame);
  }   
  frame();
  
  var argCoordinates = new Float32Array([0,0,0]);
  var argCoordinatesAngle = new Float32Array([0,0,0]);
  
  TranslateCamera(view_matr,gl,argCoordinates);
  
  TestHandleButtonUsingEventForCamera(view_matr,gl,65,argCoordinates,argCoordinatesAngle,1,true);
  TestHandleButtonUsingEventForCamera(view_matr,gl,68,argCoordinates,argCoordinatesAngle,1,false);
};
