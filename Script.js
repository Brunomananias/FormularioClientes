
function fazPost(url, body){
   console.log("body= ", body)
   let request = new XMLHttpRequest()
   request.open("POST", url, true)
   request.setRequestHeader("content-type", "application/json")
   request.send(JSON.stringify(body))

   request.onload = function() {
        console.log(this.responseText)      
   }

   return request.responseText
}

function Validar(){
  var email = Formulario.email;

  if(email.value == ""){
    alert("Email não informado");

    email.focus();
  }
}


 function CadastrarCliente(){
      event.preventDefault()
      let url= "https://localhost:44372/v1/Clientes"
      let email = document.getElementById("Email").value
      let nome = document.getElementById("Nome").value
      let cpf = document.getElementById("Cpf").value
      let telefone = document.getElementById("Tel").value
      console.log(nome)
      console.log(email)
      console.log(cpf)
      console.log(telefone)


      body = {
        "nome": nome,
        "email": email,
        "cpf": cpf,
        "telefone": telefone  
      }

      
      

      fazPost(url, body)

      
    }
    
    
     
    
    $(document).ready(function(){
     
    $('#Cpf').mask('000.000.000-00', {reverse: true});
    $('#Tel').mask('(00) 00000-0000');

    
    })
    
    
    
 

    