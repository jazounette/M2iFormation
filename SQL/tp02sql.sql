--TP SQL Exercice 2

CREATE TABLE `livre` (
	`id`		           INT NOT NULL AUTO_INCREMENT,
	`titre`	           varchar(150),
   `auteur`            varchar(50),
   `editeur`           varchar(50),
   `date_publication`  DATE,
   `isbn_10`           varchar(10),
   `isbn_13`           varchar(15),
	PRIMARY KEY(`id`)
);

--réponse 1
select id,titre from livre order by titre;

--réponse 2
select id, titre, date_publication from livre order by date_publication;

--réponse 3
select date_publication from livre order by date_publication limit 10;

--réponse 4
select * from livre order by date_publication limit 10;

--réponse 5
select date_publication, auteur, titre from livre order by date_publication limit 10;

--réponse 6
select * from livre where auteur = 'Agatha Christie';

--réponse 7
update livre set auteur='Agatha Christie' where auteur='Agatha Christies';

--réponse 8
INSERT INTO livre (titre, auteur, editeur, date_publication, isbn_10, isbn_13)
VALUES ('Extension du domaine de la lutte','Michel Houellebecq','Éditions Maurice Nadeau','1994-01-01','2253160431','978-2290349526');

--réponse 9
delete from livre where auteur='Honoré de Balzac' and titre='La Rabouilleuse';
