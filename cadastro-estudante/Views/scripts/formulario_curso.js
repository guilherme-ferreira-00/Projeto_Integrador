$(document).ready(function()
{
    listarArea();
    grid();
});

function validar(){
    let erro = false;

    let validado = verificar('id_nome', 'Nome');
    if (!validado) {
        erro = true;
        
    }

    validado = verificar('id_carga', 'Carga Horária');
    if (!validado) {
        erro = true;
    }
    
    validado = verificar('id_area', 'Area');
    if (!validado) {
        erro = true;
    }

    validado = verificarCheck(formulario.tipo, 'Tipo');
    if (!validado) {
        erro = true;
    } 
    return erro;
}

function verifica() {
   
    let erro = validar();
    let curso = {
        nome: formulario.nome.value,
        carga: parseFloat(formulario.carga.value),
        area: {
            id: parseInt(formulario.area.value)
        },
        tipo: formulario.tipo.value

    };
    
    if (!erro) {
        $.ajax({

            type: 'POST',
            url: 'https://localhost:5001/api/Curso/Cadastrar',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(curso),
            success: function(resposta){
                alert(resposta);
            },
            error: function(erro, mensagem, excecao){
                alert('Algo está incorreto!');
    }

        }
        );
    }



}


function verificar(campo, nomeCampo) {
    if (($('#'+campo).val() == '') || ($('#'+campo).val() == null) || ($('#'+campo).val() == 0)) {
        $('#'+campo).attr('class','vermelho');
        alert('Preencha o campo ' + nomeCampo + ',por favor!');
        return false;
    } else {
        return true;
    }
}

function verificarCheck(checkboxes, nomeCampo)
{
        if ($(checkboxes).is(':checked'))
        {
            return true;
        }
       alert('Preencha o campo ' + nomeCampo + ',por favor!');
       return false;
}


function remover(campo) {
    $('#'+campo).attr('class','verde');
}


function listarArea()
{
    $.get('https://localhost:5001/api/Curso/Listar')
    .done(function(resposta){
        
        for (i = 0;i < resposta.length; i++)
        {
            let option = $('<option></option>').val(resposta[i].idArea).html(resposta[i].nome);
            $('#id_area').append(option);
        }
    })
    .fail(function(erro, mensagem, excecao){
        alert('Algo está incorreto!');
    });
}

function grid()
{
    $.get('https://localhost:5001/api/Curso/CusoCadastrado')
    .done(function(resposta){
        
        for (i = 0;i < resposta.length; i++)
        {
            let linha = $('<tr></tr>');
            let celulaId = $('<td></td>').html(resposta[i].idCurso);
            let celulaNome = $('<td></td>').html(resposta[i].nome);
            let celulaCarga = $('<td class="numero"></td>').html(resposta[i].carga);
            let celulaArea = $('<td></td>').html(resposta[i].idAreaNavigation.nome);
            let celulaAcoes = $('<td></td>')
            let botaoVisualizar = $('<button></button>').attr('type','button').html('Visualizar').attr('onclick','visualizar('+ resposta[i].idCurso +')');
            let botaoExcluir = $('<button></button>').attr('type','button').html('Excluir').attr('onclick','excluir('+ resposta[i].idCurso +')');
            let botaoAlterar = $('<button></button>').attr('type', 'button').html('Alterar').attr('onclick', 'consultar(' + resposta[i].idCurso + ')');
            linha.append(celulaNome,celulaCarga,celulaArea,celulaAcoes.append(botaoVisualizar),celulaAcoes.append(botaoExcluir),celulaAcoes.append(botaoAlterar));
            $('#grid').append(linha);
           

        }
    })
    .fail(function(erro, mensagem, excecao){
        alert('Algo está incorreto!');
    });
}

function excluir(id)
{
    $.ajax({

        type: 'DELETE',
        url: 'https://localhost:5001/api/Curso/Excluir',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(id),
        success: function(resposta){
            alert(resposta);
        },
        error: function(erro, mensagem, excecao){
            alert('Algo está incorreto!!');
}

    }
    );

}

function visualizar(Id)
{
    $.get('https://localhost:5001/api/Curso/Consultar?Id=' + Id)
    .done(function(resposta){
        for (i = 0;i < resposta.length; i++)
        { 
            let visualizacao = resposta[i].nome;
            visualizacao += '\n';
            visualizacao += resposta[i].idAreaNavigation.nome;
            visualizacao += '\n';
            visualizacao += resposta[i].carga;
            visualizacao += '\n';
            visualizacao += resposta[i].tipo;
            alert(visualizacao);
        }
    })
    .fail(function(erro, mensagem, excecao){
        alert('Algo está incorreto!');
    });
}

function consultar(Id) {
    $.get('https://localhost:5001/api/Curso/Consultar?Id=' + Id)
        .done(function(resposta) {
            for (i = 0;i < resposta.length; i++)
            { 
                formulario.id.value = resposta[i].idCurso;
                formulario.nome.value = resposta[i].nome;
                formulario.carga.value = resposta[i].carga;
                formulario.area.value = resposta[i].idAreaNavigation.idArea;
                formulario.tipo[resposta[i].idCurso-1].checked = true;
                formulario.botao.innerHTML = 'ALTERAR';
                formulario.botao.onclick = alterar;
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}

function alterar() {
    let erro = validar();
    
    if (!erro) {
        let curso = {
            nome: formulario.nome.value,
            carga: parseFloat(formulario.carga.value),
            area: {
                id: parseInt(formulario.area.value)
            },
            tipo: formulario.tipo.value
    
        };

        $.ajax({
            type: 'PUT',
            url: 'https://localhost:5001/api/Curso/Alterar',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(curso),
            success: function(resposta) { 
                alert(resposta);
                limpar();
            },
            error: function(erro, mensagem, excecao) { 
                alert(mensagem + ': ' + excecao);
            }
        });
    }
}

function limpar() {
    formulario.nome.value = '';
    formulario.carga.value = '';
    formulario.area.value = 0;
    for(i = 0; i < formulario.tipo.length; i++) {
        formulario.tipo[i].checked = false;
    }
    formulario.botao.innerHTML = 'CADASTRAR';
    formulario.botao.onclick = verifica;
}