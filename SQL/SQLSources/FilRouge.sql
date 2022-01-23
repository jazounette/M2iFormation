-- source /Codage/DotNet/CSharp/SQL/SQLSources/filrouge.sql;
-- droper avant les tables avec des clées étrangères (publication et topic).

DROP TABLE IF EXISTS `publication`;

DROP TABLE IF EXISTS `topic`;

DROP TABLE IF EXISTS `utilisateur`;

-- acces le niveau d'accés utilisateur: 0:admin/1:enregistré/2:non-enreg
CREATE TABLE `utilisateur` (
	`id_user`		INT NOT NULL AUTO_INCREMENT,
   `date_user`    DATETIME,
   `nom`          VARCHAR(55),
   `prenom`       VARCHAR(55),
   `email`        VARCHAR(55) NOT NULL,
   `telephone`    VARCHAR(55),
   `pseudo`       VARCHAR(55) NOT NULL,
   `motdepasse`   VARCHAR(55) NOT NULL,
   `avatar`       VARCHAR(99),
   `acces`        INT,
	PRIMARY KEY(`id_user`)
);

INSERT INTO `utilisateur` VALUES
(NULL, CURRENT_TIMESTAMP, "cachet", "corentin", "cachet.corentin@monemail.com", "0987654321", "biroute", "toto", "urlavatar", 1),
(NULL, CURRENT_TIMESTAMP, "petit", "will", "legrand.petitwill@free.fr", "3165789865", "willfrite", "toto", "urlavatar", 1),
(NULL, CURRENT_TIMESTAMP, "dolphin", "mika", "mika.ledauphin@caramail.fr", "1565459845", "flipper", "toto", "urlavatar", 1),
(NULL, CURRENT_TIMESTAMP, "chamousse", "geronimus", "cham.gero@gmail.com", "3164169182", "jazounette", "toto", "urlavatar", 0),
(NULL, CURRENT_TIMESTAMP, "dipersio", "anthony", "anto.diper@gmail.com", "1265489845", "legrandtony", "toto", "urlavatar", 2);

CREATE TABLE `topic` (
	`id_topic`	      INT NOT NULL AUTO_INCREMENT,
   `date_top`         DATETIME,
   `id_user`         INT NOT NULL,
   `langage`         VARCHAR(55),
   `nom_topic`       VARCHAR(99),
   `description`     VARCHAR(199),
   `nb_rep`          INT,
   `arch_top`        BOOLEAN,
   `vali_top`        BOOLEAN,
	PRIMARY KEY(`id_topic`),
   FOREIGN KEY(`id_user`) REFERENCES `utilisateur`(`id_user`)
);

INSERT INTO `topic` VALUES
(NULL, CURRENT_TIMESTAMP, 1, "PHP", "jy connais rien au PHP, de l'aide j'vous en supli", "hier j'ai essayé d'apprendre ce langage des enfers, mais j'ai rien compris", 0, FALSE, TRUE),
(NULL, CURRENT_TIMESTAMP, 2, "javascript", "de l'aide JPP", "le javascript c'est trop dur, je vais me pendre", 11, FALSE, TRUE),
(NULL, CURRENT_TIMESTAMP, 5, "c#", "au secour!!!!", "chui dans une formation dotnet, le formateur il me parle dans une langue que je ne comprend pas, help me please", 33, FALSE, TRUE),
(NULL, CURRENT_TIMESTAMP, 3, "htlm/css", "c'est quoi cette balise<prout>", "ya une balise <prout> dans mon code, je sais pas comment elle est arrivé là, j'arrive pas à l'enlever", 22, FALSE, TRUE),
(NULL, CURRENT_TIMESTAMP, 4, "java", "c'est quoi la différence avec le javascript?", "bah quoi! ya juste scrypt en plus, c'est pareil non?", 5, FALSE, TRUE),
(NULL, CURRENT_TIMESTAMP, 5, "java", "titre", "description", 1, FALSE, TRUE);
-- à la création, les topics sont par défaut non archivé et validé

CREATE TABLE `publication` (
	`id_pub` 	   INT NOT NULL AUTO_INCREMENT,
   `date_pub`      DATETIME,
   `id_topic`     INT NOT NULL,
   `id_user`      INT NOT NULL,
   `arch_pub`     BOOLEAN,
   `vali_pub`     BOOLEAN,
   `message`      LONGTEXT,
	PRIMARY KEY(`id_pub`),
   FOREIGN KEY(`id_topic`) REFERENCES `topic`(`id_topic`),
   FOREIGN KEY(`id_user`) REFERENCES `utilisateur`(`id_user`)
);

INSERT INTO `publication` VALUES
(NULL, CURRENT_TIMESTAMP, 1, 1, FALSE, TRUE, "Bonjour,\nLa seule manière c'est de ne pas injecter n'importe quoi dans vos requêtes sql. Soit vous testez tous les paramètres de vos commandes sql avant de les exécuter pour être sûr qu'ils ne contiennent n'importe quoi, soit vous attachez un middleware à votre api qui fera ce test(vérifier que tous les paramètres de la requête ne contiennent pas des commandes sql) à la réception de chaque requête Pour être sûr d'y échapper et en même temps ne pas perdre du temps à gérer ça, la solution la plus sûr est d'utiliser un ORM car tous, du moins ceux que je connais, gère cela"),
(NULL, CURRENT_TIMESTAMP, 1, 4, FALSE, TRUE, "hello everyone, first of all sorry my English is not very good, so here I try to send through a request form in my database but I still have the same error. Can somebody help me please You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near '' at line 1"),
(NULL, CURRENT_TIMESTAMP, 1, 3, FALSE, TRUE, "En bref, ayez le contrôle sur toutes vos données.\nTous les formulaires interagissant avec votre base de donnée présentent de potentielles failles. Vous devez alors mettre en place des actions spécifiques vous permettant de garder le contrôle sur les données qui rentrent dans la base de donnée."),
(NULL, CURRENT_TIMESTAMP, 1, 4, FALSE, TRUE, "Les injonctions SQL aucune idée mais pour les injections SQL il y a pas mal de tuto sur le net"),
(NULL, CURRENT_TIMESTAMP, 2, 2, FALSE, TRUE, "Salut, c'est quoi le javascript?"),
(NULL, CURRENT_TIMESTAMP, 2, 1, FALSE, TRUE, "JavaScript est un langage de programmation de scripts principalement employé dans les pages web interactives mais aussi pour les serveurs avec l'utilisation (par exemple) de Node.js."),
(NULL, CURRENT_TIMESTAMP, 3, 5, FALSE, TRUE, "Quel est le rôle d'un développeur finalement? Celui de traiter, créer, rechercher de l'information. Et la plupart du temps en entreprise, l'information est stockée dans une base de donnée (relationnelle).Soyons bien clair, on ne vous demandera pas d'être un expert, mais d'avoir suffisamment de connaissance pour lire, rechercher, créer de la donnée."),
(NULL, CURRENT_TIMESTAMP, 3, 2, FALSE, TRUE, "L'une des applications les plus courantes de C# et du développement en général est l'application d'entreprise.Pour comprendre l'importance de la manipulation des bases de données, nous allons faire une brève introduction à l'architecture d'une applications d'entreprise.Une application d'entreprise typique est conçue et implémentée en utilisant des couches d'abstraction indépendantes, pour faciliter la maintenabilité et l'extensibilité.Dans la littérature de l'architecture logicielle, plusieurs auteurs ont fait référence à quatre principales couches d'abstractions:    Présentation : interactions avec l'utilisateur, validation des entrées, affichages, entrées/sorties… Application: une sous-couche de la couche métier, utilisée entre autres comme abstraction supérieure de cette dernière.  Métier: les spécificités et la logique de chaque métier sont conçues et implémentées dans cette couche sous forme de règles, calculs, contraintes et interactions entre les objets métier. L'ensemble des couches métier, application, présentation est souvent désigné par le concept MVC/MVP ( Model View Controller / Model View Presenter) Accès aux données: c'est la couche qui nous intéresse dans cette réponse. Elle lie la couche métier avec le SGBD ou le support logique de données pour faciliter et isoler la manipulation des données. Dans cette couche sont conçus et implémentés tous les accès à la base de données (ex : opérations CRUD : Create, Read, Update, Delete) . Selon le type du SGBD on y trouve des requêtes préétablies, des constructeurs de requêtes, ou parfois une sous-couche appelée ORM ( Object Relational Mapper) qui encapsule les manipulations SQL par un modèle orienté objet. L'ORM a l'avantage de pouvoir manipuler directement les objets de la couche métier entre autres (approche POCO pour C#) . L'intérêt de la bonne conception cette couche est la possibilité de changer le SGBD ou même passer du SQL au NonSQL et vice-versa sans toucher aux couches supérieures.Notez que sans la couche d'accès aux données une application entreprise typique n'a en principe pas raison d'exister.Nous avons vu un aperçu de l'importance de la couche accès aux données dans toute application entreprise. En réalité, la majorité des applications comprennent une forme ou une autre du code accès aux données ( SGBD en particulier).Il en découle qu'un développeur C# devrait en principe avoir un aperçu sur l'interaction avec les bases de données.Le modèle relationnel/SQL domine encore le monde des SGBD. Cependant il perd peu à peu du terrain en faveur d'autres approches plus modernes dites Non SQL ( Clé/Valeur, Objet…). Des exemples courants sont MongoDB et Redis.Voici quelques sujets de recherche en relation avec la question:\n\tADO .net\n\tEntity Framework\n\tLINQ\n\tSQL Server\nMerci"),
(NULL, CURRENT_TIMESTAMP, 4, 3, FALSE, TRUE, "la balise prout, j'en peux plus, elle veut pas partir"),
(NULL, CURRENT_TIMESTAMP, 4, 5, FALSE, TRUE, "il y a plusieurs méthodes pour apprendre à développer en HTML et CSS.\n\tRegarder des tutoriels sur une plateforme tel Youtube\n\tLire des tutoriels\n\tOu encore pratiquer en même temps d'apprendre\nApprendre tout en pratiquant est une des meilleures solutions afin que tu prennent l'habitude des balisages et créations des class en CSS.Pour cela je te conseille le site Codecademy. Tu trouveras ton bonheur.\nSinon il y a Grafikart et OpenClassrooms pour ce qui suit des tutoriels écrits et à regarder."),
(NULL, CURRENT_TIMESTAMP, 5, 4, FALSE, TRUE, "la question est dans le titre... s'avez pas lire...dahhh!"),
(NULL, CURRENT_TIMESTAMP, 5, 3, FALSE, TRUE, "Ce sont deux langages totalement différents."),
(NULL, CURRENT_TIMESTAMP, 5, 5, FALSE, TRUE, "JAVA —|||— JAVASCRIPT\n-Java est language de programmation orienté objet (oop) —|||— Javascript est langage de script oop : principalement utilisé dans les pages web interactives\n-Le code Java est compilé en bytecode qui est exécuté par un JVM(Java Virtual Machine) —|||— JavaScript est un langage de programmation interprété\n-Les applications Java peuvent s'executer sur n'importe quelle machine virtuelle ou navigateur —|||— Le code Javascript est exécuté sur les navigateurs uniquement\n-Java est un langage autonome —|||— JavaScript est inclut dans une page Web et s'intègre à son contenu HTML.\n-Un programme Java utilise plus de mémoire —|||— JavaScript nécessite moins de mémoire, il est donc utilisé dans des pages Web\n-Java a une approche basée sur les threads pour la gestion de la concurrence —|||— JavaScript a une approche basée sur les évenements pour la gestion de la concurrence\n-L'extension d'un fichier Java est '.java' et le code source est traduit en bytecode qui est executé par la JVM —|||— Le fichier JavaScript porte l'extension '.js' . Il est interprété mais non compilé. chaque navigateur dispose d'un interpreteur pour executer le code JavaScript\n-Les objets de Java sont basés sur les classes, on ne peut créer aucun programme en Java sans créer une classe —|||— Les objets JavaScript sont basés sur des prototypes"),
(NULL, CURRENT_TIMESTAMP, 6, 5, FALSE, TRUE, "message");

