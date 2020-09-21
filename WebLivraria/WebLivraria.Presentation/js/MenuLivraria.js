//====================================
//MenuLivraria.js
//====================================


valorGrid = {};
validarDadosLivros = function () {
    var LstMsgErro = "";
    var lboRetorno = false;
    var LstCodLivroRecemGerado = "";

    var titulo = $('#titulo').val();
    var edicao = $('#edicao').val();
    var editora = $("#listEdita").val();
    var assunto = $("#listAssuntos").val();
    var autores = $("#listAutores").val();
    var ano = $('#anoPublicacao').val();

    //Título do livro
    if (titulo == undefined || titulo == "") {
        LstMsgErro += "Título do livro , ";
    }

    // Código do Projeto
    if (edicao == undefined || edicao == "") {
        LstMsgErro += "Edição , ";
    }

    // Qual a editora escolhida
    if (editora == undefined || editora == 0) {
        LstMsgErro += "Editora escolhida , ";
    }

    if (assunto == undefined ||assunto == "") {
        LstMsgErro += "Assunto escolhido, ";
    }

    if (autores == undefined || autores == "") {
        LstMsgErro += "Autor escolhido, ";
    }

    if (ano == undefined || ano == "") {
        LstMsgErro += "Ano da Publicação , ";
    }

    if (LstMsgErro != "") {
        LboRetorno == false;
       // hideLoading();
       // $.growl({ title: "ATENÇÃO:", message: "Campo(s) obrigatório(s) e que não foram preenchido(s):" + LstMsgErro + ".", fixed: false, style: 'warning', duration:10000 });
       // return false;
    }
    else {
        LboRetorno = true;
    }

        return LboRetorno;
    }

var valorDosDados = {};
    $(".name").text
 
function LimparTelaDados() {

    //Apaga as variáveis de sessão.
    $("#ctl00_ContentPlaceHolderWebLivraria_titulo").val('');
    $("#ctl00_ContentPlaceHolderWebLivraria_edicao").val('');
    $('#hdnEditora').val(-1);
    //$('#ctl00_ContentPlaceHolderWebLivraria_listEdita option[value="-1"]').prop('selected', 'selected');
    $('#hdnCodAssunto').val(-1);
    $('#listAssuntos option[value="-1"]').prop('selected', 'selected');
    $('#hdnAutor').val(-1);
    $('#listAutores option[value="-1"]').prop('selected', 'selected');
    $('#anoPublicacao').val('');
    $('#ValLivro').val('0.00');
}
// Limpa o campo do form assunto
limparTela = function() {
    $('#ctl00_ContentPlaceHolderWebLivraria_hdnCodAssunto').val('');
    $('#ctl00_ContentPlaceHolderWebLivraria_nmAssunto').val('');
}
$('body').on('click', '.chkDoLivro', function () {

    var $col = $(this).find('td');
    $('#ctl00_ContentPlaceHolderWebLivraria_hdnCodLivro').val($col[0].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_titulo').val($col[1].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_listEdita').val($col[2].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_edicao').val($col[3].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_listAssuntos').val($col[4].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_listAutores').val($col[5].innerText)
    $('#ctl00_ContentPlaceHolderWebLivraria_anoPublicacao').val($col[6].innerText);
    $('#ctl00_ContentPlaceHolderWebLivraria_ValLivro').val($col[7].innerText);
    $('#btnBotao').val('alterar');
});

$('body').on('click', '.chkDoAutor', function () {
    var $coluna = $(this).find('td');
    $('#ctl00_ContentPlaceHolderWebLivraria_hdnAutores').val($coluna[0].innerText);
});

$('body').on('click', '.chkCodAssunto', function () {
    var $coluna = $(this).find('td');
    $('#ctl00_ContentPlaceHolderWebLivraria_hdnCodAssunto').val($coluna[0].innerText);
});