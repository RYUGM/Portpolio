



const spawn = require('child_process').spawn
// import { spawn } from 'child_process';
const result = spawn('python', ['ex03.py']);



    result.stdout.on('data',function(data){
        let ml_txt=data.toString()
        console.log(ml_txt);
        // document.getElementById('ml').innerText=ml_txt

        return ml_txt;
        
        
    });



