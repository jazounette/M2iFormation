DROP TABLE IF EXISTS `banqueope`;

DROP TABLE IF EXISTS `banquecompte`;

CREATE TABLE `banquecompte` (
	`id_cp`		         INT NOT NULL AUTO_INCREMENT,
   `date_cp`            DATETIME,
	`numero`	            INT,
   `solde`              FLOAT,
   `nombreope`          INT,
   `clientnom`          VARCHAR(44),
   `clientpre`          VARCHAR(44),
   `clienttel`          VARCHAR(44),
   `type`               TINYINT,
   `taux`               FLOAT,
	PRIMARY KEY(`id_cp`)
);
-- type de compte gratuit(1), épargne(2) ou payant(3)

CREATE TABLE `banqueope` (
	`id_op`		         INT NOT NULL AUTO_INCREMENT,
	`date_op`	         DATETIME,
   `montant`            FLOAT,
   `compte_id`          INT NOT NULL,
	PRIMARY KEY(`id_op`),
   FOREIGN KEY(`compte_id`) REFERENCES `banquecompte`(`id_cp`)
);
/*
CREATE TABLE `table_users` (									//sous table
	`id_user` INT NOT NULL AUTO_INCREMENT,
	.....toutes les colonnes que l'ont veux....
	PRIMARY KEY(`id_user`)
);
CREATE TABLE `table_news` (									//table principale
	`id_news` INT NOT NULL AUTO_INCREMENT,
	......liste de colonnes......
	`news_auteur` INT NOT NULL,								//contient pointeur vers la "sous table" ici table_users, attention a avoir le même type, ici INT
	PRIMARY KEY(`id_news`),
	FOREIGN KEY(`news_auteur`) REFERENCES `table_users`(`id_user`)
);
*/


insert into banquecompte values 
(NULL, CURRENT_TIMESTAMP, 1111, 99.99, 4, "Legrand", "Zorro", "1265458965", 1, 1),
(NULL, CURRENT_TIMESTAMP, 1112, 333.99, 3, "Rodriguez", "Raoul", "1523654589", 2, 5.5),
(NULL, CURRENT_TIMESTAMP, 1113, 265.65, 1, "Lagaffe", "Gaston", "6532651598", 3, 2.2);

insert into banqueope values
(NULL, CURRENT_TIMESTAMP, 1111.55, 1),
(NULL, CURRENT_TIMESTAMP, -222.1234, 1),
(NULL, CURRENT_TIMESTAMP, 333, 1),
(NULL, CURRENT_TIMESTAMP, -11,1),
(NULL, CURRENT_TIMESTAMP, 3333, 2),
(NULL, CURRENT_TIMESTAMP, -444, 2),
(NULL, CURRENT_TIMESTAMP, -55.64, 2),
(NULL, CURRENT_TIMESTAMP, 1326, 3);


