--TP SQL Exercice 1

CREATE TABLE `personne` (
	`id`			INT NOT NULL AUTO_INCREMENT,
	`titre`		varchar(55),
   `prenom`    varchar(55),
   `nom`       varchar(55),
   `email`     varchar(55),
   `telephone` varchar(55),
	PRIMARY KEY(`id`)
);

INSERT INTO `personne` VALUES
(NULL, "Mlle", "Tata", "Toto", "tatatoto@monemail.com", "0987654321"),
(NULL, "M.", "Minet", "Gros", "grosminet@monemail.com", "0612345678"),
(NULL, "Mme", "Jane", "Doe", "janedoe@gmail.com", "0987654321"),
(NULL, "M.", "Bernard", "Minet", "bernard.m@free.fr", "0614762345"),
(NULL, "Mlle", "Jessica", "Rabbit", "jr@caramail.fr", "0677777777"),
(NULL, "M.", "Zorro", "Legrand", "dondiego@gmx.com", "0987654321"),
(NULL, "Mme", "Foo", "Bar", "foo@bar.com", "0913243546");

select * from personne order by nom; -- question 2, affiche tout le monde, classé par nom de famille croissant

select * from personne order by titre; -- question 3, affiche tout le monde, classé par titre

select * from personne where email='foo@bar.com'; -- question 4, recherche un email dans la base de donnée
