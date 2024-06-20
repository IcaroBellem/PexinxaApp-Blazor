/*function search(){
    let input = document.getElementById('pesquisa').value
    input = input.toLowerCase()

    //categorias
    let categorias = document.getElementsByClassName('categorias')
    let produtos = document.getElementsByClassName('produtos')

    for(i = 0; i< categorias.length; i++){
        if(!categorias[i].innerHTML.toLocaleLowerCase().includes(input)){
            categorias[i].style.display="none"
            
        }

        else{
            categorias[i].style.display = "list-item"

        }
    
    }

    for(i = 0; i< produtos.length; i++){
        if(!produtos[i].innerHTML.toLocaleLowerCase().includes(input)){
            produtos[i].style.display="none"
            
        }

        else{
            produtos[i].style.display = "list-item"

        }
    
    }*/


function search() {
    // Obtém o valor de entrada do usuário
    var sea
    rchValue = document.getElementById('pesquisa').value.toLowerCase();

    // Seleciona todos os produtos
    var produtos = document.querySelectorAll('.produtos');

    // Itera sobre cada produto para verificar se corresponde à busca
    for (var i = 0; i < produtos.length; i++) {
        var produtosName = produtos[i].getAttribute('data-name').toLowerCase();
        var produtosMarket = produtos[i].getAttribute('data-market').toLowerCase();

        // Verifica se o nome do produto ou o mercado corresponde à busca
        if (produtosName.includes(searchValue) || produtosMarket.includes(searchValue)) {
            produtos[i].style.display = 'block';  // Exibe o produto
        } else {
            produtos[i].style.display = 'none';   // Oculta o produto
        }
    }
}






