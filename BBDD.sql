DROP DATABASE IF EXISTS Othello;
CREATE DATABASE Othello;
USE Othello;

CREATE TABLE Jugador (
Username VARCHAR(20) PRIMARY KEY NOT NULL,
Password VARCHAR(10),
Nivel INTEGER NOT NULL
)ENGINE = InnoDB;

CREATE TABLE Partida(
id INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
Ganador VARCHAR(20) NOT NULL,
LimitePartida TIME
  )ENGINE = InnoDB;

CREATE TABLE Juego(
idJuego INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
idPartida INTEGER,
Username1 VARCHAR(20) NOT NULL,
Username2 VARCHAR(20) NOT NULL,
FOREIGN KEY (idPartida) REFERENCES Partida(id),
FOREIGN KEY (Username1) REFERENCES Jugador(Username),
FOREIGN KEY (Username2) REFERENCES Jugador(Username)
)ENGINE = InnoDB;

INSERT INTO Jugador VALUES('Marina21', 'Ma12345Pad', 4);
INSERT INTO Jugador VALUES('Juan10', 'Asdfghjk12', 10);
INSERT INTO Jugador VALUES('Carla55', 'QWertyu857', 5);
INSERT INTO Jugador VALUES('Anna33', 'QDesfrtn27', 15);

INSERT INTO Partida VALUES(1,'Marina21','10:00:00');
INSERT INTO Partida VALUES(2,'Carla55','10:00:00');
INSERT INTO Partida VALUES(3,'Juan10','10:00:00');
INSERT INTO Partida VALUES(4,'Marina21','10:00:00');

INSERT INTO Juego VALUES(1,1,'Marina21','Juan10');
INSERT INTO Juego VALUES(2,2,'Carla55','Juan10');
INSERT INTO Juego VALUES(3,3,'Anna33','Juan10');
INSERT INTO Juego VALUES(4,4,'Marina21','Carla55');