
$("#demo-form").submit(function(e){
  e.preventDefault();

  CadastrarCliente()
});




function CriarObjetoCliente() {
    var cliente = {
      email: $("#Email").val(),
      cpf: $("#Cpf").val(),   //Obtendo o valor do CPF e NOME da API//
      nome: $("#Nome").val(),
      telefone: $("#Tel").val(),
      
    };
    return cliente;
  }

  //Inserir clientes//
  function CadastrarCliente() {
        //Usando o IF para validar o formulário//
      var objCliente = CriarObjetoCliente();
      var jsonCliente = JSON.stringify(objCliente);

      $.ajax({
        method: "POST",
        url: "https://localhost:44372/v1/Clientes",//Usando o POST para inserir clientes da API//
        data: jsonCliente,
        contentType: "application/json"
      }).done(function (resposta) {
        console.log(resposta);
      }).fail(function (details, error) {
        console.log(details);
        console.log(error);
      });
    }
  

   