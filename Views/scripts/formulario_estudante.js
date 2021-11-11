$(document).ready(function()
{
    listarCurso();
    grid();
    listaridDisciplina();
});

function validar() {
   
    let erro = false;

    let validado = verificar("id_nome", 'Nome');
    if (!validado) {
        erro = true;
    }

    validado = verificar("id_idade", 'Idade');
    if (!validado) {
        erro = true;
    }
    
    validado = verificar("id_data", 'Data de Ingresso');
    if (!validado) {
        erro = true;
    }

    validado = verificar("id_curso", 'Curso');
    if (!validado) {
        erro = true;
    }


    validado = verificarCheck(formulario.disciplina, 'Disciplinas');
    if (!validado) {
        erro = true;
    }

    
    validado = verificarCheck(formulario.graduado, 'Graduado');
    if (!validado) {
        erro = true;
    }

    return erro;

}

function verifica() {
   
    let erro = validar();
    
    
    var dis = getValues();
    
    
    if (!erro) {  
        
        var id;
        var url;
        var metodo;
        if (formulario.botao.innerHTML == 'ALTERAR'){
            id = formulario.id.value;
            metodo = 'PUT';
            url = 'https://localhost:5001/api/Estudante/Alterar';
        }
        else{
            id = 0;
            metodo = 'POST';
            url = 'https://localhost:5001/api/Estudante/Cadastrar';
        }

        var novoEstudante = {
            id: parseFloat(id),
            nome: formulario.nome.value,
            idade: parseFloat(formulario.idade.value),
            data: formulario.data.value,
            IdcursoDisciplina: parseInt(dis),
            IdcursoEstudante: parseInt(formulario.curso.value),
            graduado: parseInt(formulario.graduado.value),
            IdCurso: parseInt(formulario.curso.value)
    
        };
               
        $.ajax({

        type: metodo,
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(novoEstudante),
        success: function(resposta){
            alert(resposta);
            grid();
            limpar();
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


function getValues() {
    var pacote = document.querySelectorAll('[name=disciplina]:checked');
    var values = [];
    for (var i = 0; i < pacote.length; i++) {
      values.push(pacote[i].value);
    }
    return values
  }

function remover(campo) {
    $('#'+campo).attr('class','verde');
}

function listarCurso()
{
    $.get('https://localhost:5001/api/Estudante/Listar')
    .done(function(resposta){
        
        for (i = 0;i < resposta.length; i++)
        {
            let option = $('<option></option>').val(resposta[i].idcursoEstudante).html(resposta[i].nome);
            $('#id_curso').append(option);
        }
    })
    .fail(function(erro, mensagem, excecao){
        alert('Algo está incorreto!');
    });
}

function grid()
{
    $.get('https://localhost:5001/api/Estudante/EstudanteCadastrado')
    .done(function(resposta){
        $('#grid tr').remove();
        for (i = 0;i < resposta.length; i++)
        {
            
            let linha = $('<tr></tr>');
            let celulaId = $('<td></td>').html(resposta[i].id);
            let celulaNome = $('<td></td>').html(resposta[i].nome);
            let celulaIdade = $('<td class="numero" ></td>').html(resposta[i].idade);
            let celulaData = $('<td></td>').html(resposta[i].data);
            let celulaCurso = $('<td></td>').html(resposta[i].idCursoNavigation.nome);
            let celulaGraduado = $('<td></td>').html(resposta[i].graduado);
            let celulaAcoes = $('<td></td>')
            let botaoVisualizar = $('<button></button>').attr('type','button').html('Visualizar').attr('onclick','visualizar('+ resposta[i].id +')');
            let botaoExcluir = $('<button></button>').attr('type','button').html('Excluir').attr('onclick','excluir('+ resposta[i].id +')');
            let botaoAlterar = $('<button></button>').attr('type', 'button').html('Alterar').attr('onclick', 'consultar(' + resposta[i].id + ')');
            linha.append(celulaNome,celulaIdade,celulaData,celulaCurso,celulaGraduado,celulaAcoes.append(botaoVisualizar),celulaAcoes.append(botaoExcluir),celulaAcoes.append(botaoAlterar));
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
        url: 'https://localhost:5001/api/Estudante/Excluir',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(id),
        success: function(resposta){
            alert(resposta);
            grid();
        },
        error: function(erro, mensagem, excecao){
            alert('Algo está incorreto!!');
}

    }
    );

}

function visualizar(idCurso)
{
    $.get('https://localhost:5001/api/Estudante/Consultar?idCurso=' + idCurso)
    .done(function(resposta){
        for (i = 0;i < resposta.length; i++)
        {
            let visu = resposta[i].nome;
            visu += '\n';
            let visualizacao = resposta[i].idade;
            visualizacao += '\n';
            visualizacao += resposta[i].data;
            visualizacao += '\n';
            visualizacao += resposta[i].idcursoEstudanteNavigation.nome;
            visualizacao += '\n';
            visualizacao += resposta[i].idcursoDisciplinaNavigation.nome;
            visualizacao += '\n';
            visualizacao += resposta[i].graduado;
            alert(visu+visualizacao);
        }
    })
    .fail(function(erro, mensagem, excecao){
        alert('Algo está incorreto!');
    });
}


function consultar(idCurso) {
    $.get('https://localhost:5001/api/Estudante/Consultar?idCurso='+idCurso)
        .done(function(resposta) { 
            limpar();
            for (i = 0;i < resposta.length; i++)
            {
                
                formulario.id.value = resposta[i].id;
                formulario.nome.value = resposta[i].nome;
                formulario.data.value = resposta[i].data;
                formulario.idade.value = resposta[i].idade;
                formulario.curso.value = resposta[i].idcursoEstudanteNavigation.idcursoEstudante;
                formulario.disciplina.value = resposta[i].idcursoDisciplinaNavigation.idcursoDisciplina;
                formulario.disciplina[resposta[i].idcursoDisciplinaNavigation.idcursoDisciplina-1].checked = true;
                formulario.graduado[resposta[i].graduado-1].checked = true;
                formulario.botao.innerHTML = 'ALTERAR';
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert(mensagem + ': ' + excecao);
        });
}
function limpar() {
    formulario.nome.value = '';
    formulario.idade.value = '';
    formulario.data.value = '';
    formulario.curso.value = 0;
    for(i = 0; i < formulario.graduado.length; i++) {
        formulario.graduado[i].checked = false;
    }
    for(i = 0; i < formulario.disciplina.length; i++) {
        formulario.disciplina[i].checked = false;
    }
    formulario.botao.innerHTML = 'CADASTRAR';
    formulario.botao.onclick = verifica;
}


function listaridDisciplina() {
    $.get('https://localhost:5001/api/Estudante/Listardis')
        .done(function(resposta) { 
            for(i = 0; i < resposta.length; i++) {
                if (i > 0)
                {
                    $('#iddisciplina').append($('<br>'));
                }

                $('#iddisciplina').append($('<input>').attr('type', 'checkbox').attr('name', 'disciplina').val(resposta[i].idcursoDisciplina));
                $('#iddisciplina').append(resposta[i].nome);
            }
        })
        .fail(function(erro, mensagem, excecao) { 
            alert('Algo está incorreto!');
        });
}

