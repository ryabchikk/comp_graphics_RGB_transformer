
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
      gl_FragColor = mix(texture2D(Texture,texCoord),texture2D(Texture1,texCoord),textureWeight);
    }
`

var vTetrahedronShaderSource = 
`precision mediump float;
    attribute vec3 vertPos;
    attribute vec3 u_color;
    varying vec3 color;
    uniform mat4 view;
    uniform mat4 projection;
    uniform mat4 world;
    void main()
    {
      color = u_color;
      gl_Position = projection*view * world*vec4(vertPos,1.0);
    }
`
var fTetrahedronShaderUniformSource = 
`
   precision mediump float;
   varying vec3 color;
    void main()
    {
      gl_FragColor = vec4(color,1.0);
    }
`

var start = function(){

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
   //gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('crate'));

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

   var canvas = document.getElementById("task3");
   var gl = canvas.getContext('webgl');

   if(!gl){
       console.log("error!");
   }
  
  SetDefaultSettings(gl);

   var vertexShader =  CreateShader(gl,gl.VERTEX_SHADER,vShaderSource); 
   var fragmentShader =  CreateShader(gl,gl.FRAGMENT_SHADER,fShaderUniformTexturesSource);
  
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

  var second_texture = gl.createTexture();
  

  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 


  //gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('crate'));

  gl.bindTexture(gl.TEXTURE_2D,null);
  gl.bindTexture(gl.TEXTURE_2D,second_texture);

  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_S,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D,gl.TEXTURE_WRAP_T,gl.CLAMP_TO_EDGE);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.LINEAR);
  gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.LINEAR); 

  //gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, gl.RGBA, gl.UNSIGNED_BYTE, document.getElementById('nebula'));

   var programTextures = CreateProgram(gl,vertexShader,fragmentShader);
   gl.useProgram(programTextures); 
  
    var pos_attr = gl.getAttribLocation(programTextures,"vertPos");
    gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,0);
     
    var color_attr = gl.getAttribLocation(programTextures,"u_color");
    gl.vertexAttribPointer(color_attr,3,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);
     
    var text_attr = gl.getAttribLocation(programTextures,"_textCoord");
    gl.vertexAttribPointer(text_attr,2,gl.FLOAT,gl.FALSE,8*Float32Array.BYTES_PER_ELEMENT,6*Float32Array.BYTES_PER_ELEMENT);

    var textureWeight = gl.getUniformLocation(programTextures,'textureWeight');
    gl.uniform1f(textureWeight,0.5);
   
      
    gl.enableVertexAttribArray(pos_attr);
    gl.enableVertexAttribArray(color_attr); 
    gl.enableVertexAttribArray(text_attr); 
   
   
    var view_matr = gl.getUniformLocation(programTextures,'view');
    var proj_matr = gl.getUniformLocation(programTextures,'projection');
    var world_matr = gl.getUniformLocation(programTextures,'world');

    var viewmat4 = GetViewMatrix([0,0,-10],[0,0,0],[0,1,0]);
    var projectionmat4 = GetPerspectiveMatrix(toRadians(45),canvas.width / canvas.clientHeight,0.1,1000.0);
    var worldm4 = MultiplayMatrix(GetRotationMatrixX(40),GetRotationMatrixY(40),4,4);
    
    gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
    gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
    gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);

      
    gl.activeTexture(gl.TEXTURE0);
    gl.bindTexture(gl.TEXTURE_2D,texture); 
    gl.uniform1i(gl.getUniformLocation(programTextures,'Texture'),0);  

    gl.activeTexture(gl.TEXTURE1);
    gl.bindTexture(gl.TEXTURE_2D,second_texture); 
    gl.uniform1i(gl.getUniformLocation(programTextures,'Texture1'),1);  
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
     if(key==39){
        textWeight += 0.1;
        textWeight = Math.min(textWeight,1.0);
       SetDefaultSettings(gl);
        gl.uniform1f(textureWeight,textWeight);
        gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
     }
     else if(key==37){
        textWeight -= 0.1;
        textWeight = Math.max(textWeight,0.0);
         SetDefaultSettings(gl);
         gl.uniform1f(textureWeight,textWeight);
        gl.drawElements(gl.TRIANGLES,cubeIndexCoords.length,gl.UNSIGNED_SHORT,0);
     }
    });
 
};

var start_tetrahedron = function(){
    var canvas = document.getElementById("task1");
    var gl = canvas.getContext('webgl');

    if(!gl){
        console.log("error!");
    }
   
    SetDefaultSettings(gl);
  
    var vertexShader =  CreateShader(gl,gl.VERTEX_SHADER,vTetrahedronShaderSource); 


    var fragmentShader =  CreateShader(gl,gl.FRAGMENT_SHADER,fTetrahedronShaderUniformSource);
   
   var tetrahedronCoords = GetTetrahedronCoordinates();
   var tetrahedrVertexPosBuffer = gl.createBuffer();
   gl.bindBuffer(gl.ARRAY_BUFFER,tetrahedrVertexPosBuffer);
   gl.bufferData(gl.ARRAY_BUFFER,tetrahedronCoords,gl.STATIC_DRAW);
   
   var tetrahedronIndexCoords = GetTetrahedronIndeces();
   var tetrahedronIndexBuffer =  gl.createBuffer();
   gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER,tetrahedronIndexBuffer);
   gl.bufferData(gl.ELEMENT_ARRAY_BUFFER,tetrahedronIndexCoords,gl.STATIC_DRAW);
   

   

   var program = CreateProgram(gl,vertexShader,fragmentShader);
   gl.useProgram(program); 
  
    var pos_attr = gl.getAttribLocation(program,"vertPos");
    gl.vertexAttribPointer(pos_attr,3,gl.FLOAT,gl.FALSE,6*Float32Array.BYTES_PER_ELEMENT,0);
     
    var color_attr = gl.getAttribLocation(program,"u_color");
    gl.vertexAttribPointer(color_attr,3,gl.FLOAT,gl.FALSE,6*Float32Array.BYTES_PER_ELEMENT,3*Float32Array.BYTES_PER_ELEMENT);
     
      
    gl.enableVertexAttribArray(pos_attr);
    gl.enableVertexAttribArray(color_attr); 

   
   
    var view_matr = gl.getUniformLocation(program,'view');
    var proj_matr = gl.getUniformLocation(program,'projection');
    var world_matr = gl.getUniformLocation(program,'world');

    var viewmat4 = GetViewMatrix([0,0,-10],[0,0,0],[0,1,0]);
    var projectionmat4 = GetPerspectiveMatrix(toRadians(45),canvas.width / canvas.clientHeight,0.1,1000.0);
    var worldm4 = MultiplayMatrix(GetRotationMatrixX(10),GetRotationMatrixY(5),4,4);
    //var worldm4 = GetIdentity();
    gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
    gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
    gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);

    gl.drawElements(gl.TRIANGLES,tetrahedronIndexCoords.length,gl.UNSIGNED_SHORT,0);
    var Y=0;
    var X=0;

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
        if(key==40){
            Y-=1;
            var worldm4 = GetTranslateMatrixXYZ(X,Y,0);
            //var worldm4 = GetIdentity();
            SetDefaultSettings(gl);
            gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
            gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
            gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);
        
            gl.drawElements(gl.TRIANGLES,tetrahedronIndexCoords.length,gl.UNSIGNED_SHORT,0);
        }
        else if(key==38){
            Y+=1;
            var worldm4 = GetTranslateMatrixXYZ(X,Y,0);
            //var worldm4 = GetIdentity();
            SetDefaultSettings(gl);
            gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
            gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
            gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);
        
            gl.drawElements(gl.TRIANGLES,tetrahedronIndexCoords.length,gl.UNSIGNED_SHORT,0);
        }
       });
       addEvent(document,'keydown',function(e){
        e = e || window.event;
        var key = e.which || e.keyCode;
        if(key==39){
            X-=1;
            var worldm4 = GetTranslateMatrixXYZ(X,Y,0);
            //var worldm4 = GetIdentity();
            SetDefaultSettings(gl);
            gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
            gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
            gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);
        
            gl.drawElements(gl.TRIANGLES,tetrahedronIndexCoords.length,gl.UNSIGNED_SHORT,0);
        }
        else if(key==37){
            X+=1;
            var worldm4 = GetTranslateMatrixXYZ(X,Y,0);
            //var worldm4 = GetIdentity();
            SetDefaultSettings(gl);
            gl.uniformMatrix4fv(world_matr,gl.FALSE,worldm4);
            gl.uniformMatrix4fv(view_matr,gl.FALSE,viewmat4);
            gl.uniformMatrix4fv(proj_matr,gl.FALSE,projectionmat4);
        
            gl.drawElements(gl.TRIANGLES,tetrahedronIndexCoords.length,gl.UNSIGNED_SHORT,0);
        }
       });
    
};


