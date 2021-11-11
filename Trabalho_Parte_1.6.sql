create DATABASE cadastro_estudante;


USE cadastro_estudante;
CREATE TABLE Area
(
	IdArea INTEGER AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL
);

CREATE TABLE Cursodisciplina
(
	IdcursoDisciplina INTEGER AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL
);

CREATE TABLE Cursoestudante
(
	IdcursoEstudante INTEGER AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(80) NOT NULL
);
 

CREATE TABLE Curso
(
IdCurso INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(80) NOT NULL,
Carga double,
Tipo VARCHAR(80) NOT NULL,
IdArea INTEGER NOT NULL,
FOREIGN KEY (IdArea) references Area(IdArea)
);

 

CREATE TABLE Estudante
(
Id INTEGER AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(30) NOT NULL,
Data VARCHAR(11) NOT NULL,
Idade INTEGER NOT NULL,
Graduado integer NOT NULL,
IdCurso INTEGER NOT NULL,
FOREIGN KEY (IdCurso) references Curso(IdCurso),
IdcursoDisciplina INTEGER NOT NULL,
FOREIGN KEY (IdcursoDisciplina) references cursoDisciplina(IdcursoDisciplina),
IdcursoEstudante INTEGER NOT NULL,
FOREIGN KEY (IdcursoEstudante) references cursoEstudante(IdcursoEstudante)
);

INSERT INTO 
    Cursodisciplina(Nome)
VALUES
	("Cálculo I"),
	("Lógica Matemática"),
    ("Sistemas Operacionais"),
    ("Análise de Algoritmos");
    
INSERT INTO 
    Cursoestudante(Nome)
VALUES
	("Analise e desenvolvimaneto de sistemas"),
	("Ciência da Computação"),
    ("Sistema de informação"),
    ("Biologia");

INSERT INTO 
    Area(Nome)
VALUES
	("Exatas"),
    ("Exatas"),
    ("Humanas"),
    ("Biologicas");




INSERT INTO 
    curso(Nome,carga,Tipo, IdArea)
VALUES
    ("Análise e Desenvolvimento de Sistemas",80,"1",1),
    ("Análise e Desenvolvimento de Sistemas",45,"2",2),
    ("Filosofia",60,"3",3),
    ("Biologia",50,"4",4);



INSERT INTO 
    Estudante(Nome, Idade, Graduado, Data, IdCurso ,IdcursoDisciplina,IdcursoEstudante)
VALUES
    ("Emilly", 23, 2, "2011-01-02",1,1,1),
    ("Jasmine",19, 1, "2020-01-02",2,2,2),
    ("Filip", 21 , 1, "2019-01-02",3,3,3),
    ("José",33, 2,"2009-01-08" ,4,4,4);
select * from estudante;


ALTER TABLE estudante ADD excluido BOOLEAN;

UPDATE estudante SET excluido = false;

ALTER TABLE estudante CHANGE COLUMN excluido excluido BOOLEAN NOT NULL;

ALTER TABLE curso ADD excluido BOOLEAN;

UPDATE curso SET excluido = false;

ALTER TABLE curso CHANGE COLUMN excluido excluido BOOLEAN NOT NULL;