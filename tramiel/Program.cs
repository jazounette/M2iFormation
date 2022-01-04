// See https://aka.ms/new-console-template for more information
using System.Text;
using UtilitaireJC;

//////////////////// pour avoir les accents, changer la police de la console
// si choix1 = 99 alors mauvaise réponse on redirige automatiquement après une pause sur choix2
// si choix1 = 98 alors bonne réponse, on redirige sur choix2 après pause, pas de perte de points
// si choix1 = 97 alors FIN
// sinon, le joueur choisi ou il veux se rendre, si choix vaut 0 alors ne pas afficher
string intro = "Cette fois, vous êtes piégé! Le doigt du destin et de Michaël Thévenet, le spécialiste incontesté de l'interactivité jubilatoire, vous a désignée. Vous allez vous mesurer avec le seul, l'unique, le terrific Jack Tramiel. De sa naissance à aujourd'hui, de Commodore à Atari, il vous faudra prendre les bonnes décisions, faire les bons choix. Good luck!";
string régle = "Les deux règles d'or de l'enquête, Règle première: vous débutez la lecture au numéro 1. Suivant vos choix, passez de paragraphe en paragraphe pour revivre pas à pas la vie trépidante de Jack Tramiel. Règle deuxième: pour mener à bien cette vie par procuration, vous disposez d'un indice de Tramielitude, placé à 100 au départ. Tout choix biographique inexact entraîne une chute de l'indice. S'il tombe à zéro, vous échouez lamentablement!";
livre[] tramiel = {
   new livre(0, 0, 0, 0, 0, "0. ya rien ici, c'est vide et froid."), // on index pas la premiere valeur(0) pour pouvoir commencer à 1
   new livre(15, 22,  8, 0, 0,  "1. Pour bien démarrer une carrière aussi époustouflante que celle de Jack Tramiel, il s'agit de commencer en fanfare par la naissance appropriée. Choississez votre lieu de naissance: \n\n1 - Popowo (>>15),\n2 - Lodz (>>22)\n3 - Wadowice (>>8)."),
   new livre(44, 30,  9, 0, 0,  "2. Sam, le président d'Atari, est diplômé de Business de l'Université York au Canada. Leonard, vice-président, a un doctorat d'astrophysique. Gary, le secrétaire et trésorier, est diplômé du Menlo Business College. Vous pouvez être fier de votre progéniture! Et que faites-vous avec vos enfants, de vos salaires mirifiques:\n\n1 - jouez-vous à Las Vegas (>>44)\n2 - achetez-vous des voitures (>>30)\n3 - investissez-vous dans la pierre (>>9)?"),
   new livre(23, 37,  0, 0, 0,  "3. Vous voici fortune faite et votre pari contre l'impossible réussi avec Atari. Vous appréciez la France et savez que tout s'y termine en chanson.\n\n1 - Entonnez-vous l'hymne américain (>>23)\n2 - interprétez-vous un air d'opéra (>>37)?"),
   new livre(26, 12, 33, 0, 0,  "4. L'euphorie se poursuit jusqu'en 1974, avec les calculettes mais aussi les montres et d'autres gadgets électroniques. En 1974, premier coup de semonce: Texas refuse de livrer et lance ses propres calculettes.\n\n1 - Rachetez-vous Texas Instruments (>>26)\n2 - arrêtez-vous de fabriquer (>>12)\n3 - attaquez-vous Texas sur son marché (>>33) ?"),
   new livre(99, 40, 0, 0,-10,  "5. Le succès ne vous monte pas à la tête et vous vous rendez compte du manque d'avenir des additionneuses. Vous revendez les bases européennes à Dolittle (moyennant un confortable bénéfice) et réinvestissez aux États-Unis.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 40."),
   new livre(41, 13, 0, 0,  0,  "6. Le sens divin des affaires vous à déjà touché. Avec votre boutique, vous entassez des piles de dollars qui vous servent à fonder Commodore Portable Typewriter en 1954. Avec cette société,\n\n1 - vous engagez-vous dans l'export (>>41)\n2 - ou dans l'import (>>13) ?"),
   new livre(98, 21, 0, 0,  0,  "7. L'armée américaine, toute resplendissante des succès remportés en Europe vous attire, pas tant pour la gloriole que pour l'opportunité d'apprendre un métier. Vous vous engagez, et obtenez d'office la nationalité américaine. Durant cette période vous devenez réparateur de machine à écrire.\nRendez-vous au 21."),
   new livre(99, 22, 0, 0,-10,  "8. Célèbre est devenu ce sacré Karol Wojtyla, autrement dit le pape. Mais pour vous, il fallait viser Lodz!\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 22."),
   new livre(99, 30, 0, 0,-10,  "9. Dès que vous possédez un foyer confortable, vous n'éprouvez pas le besoin d'avoir d'autres résidences. Les hôtels n'existent pas que pour les autres!\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 30."),
   new livre(45, 31, 0, 0,  0, "10. La Warner Communication perd environ 1 million de dollars par jour avec sa filiale Atari. Gros joueur, vous misez quelques millions de dollars là-dessus et engagez vos fils et d'autres investisseurs sur l'affaire.\n\n1 - Mais gardez-vous la majorité des parts (>>45)\n2 - ou n'avez-vous pas assez d'argent (>>31) ?"),
   
   new livre(98, 25, 0, 0,  0, "11. Vous versez un salaire royal à Chuck, En échange, il vous apporte sur un plateau l'un des premiers micro-ordinateurs du marché: le PET, Dès 1977, vous envahissez les rayons des boutiques avec votre machine. En 1981, vous attaquez le marché de la console avec le Vic20. Dans l'opération, vous obligez Texas à abandonner son TI99, trop coûteux à fabriquer pour tenir face à vos prix au ras du plancer. 1983 vous apporte la consécration avec le C64.\nRendez-vous au 25."),
   new livre(99, 33, 0, 0,-10, "12. Arrêter la production? Plutôt mourir! Et ce ne sont pas des gens déloyaux comme Texas Instruments qui vont vous arrêter sur la route de la fortune!\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 33."),
   new livre(98, 27, 0, 0,  0, "13. Doté d'un flair hors du commun et d'une volonté de diffuser les nouvelles technologies au plus grand nombre, vous choisissez d'importer des additionneuses d'Europe pour une distribution aux États-Unis.\nRendez-vous au 27."),
   new livre(50,  7, 0, 0,-10, "14. L'obtention de la nationalité ne traîne pas pour les nouveaux immigrants, pourtant vous ne la solicitez pas en débarquant sur le continent américain.\nVotre indice de Tramielitude chute de 10.\n\n1 - Choisissez entre la vente des journeaux (>>50)\n2 - ou l'armée (>>7)."),
   new livre(99, 22, 0, 0,-10, "15. Bien sûr, le prix Nobel de la Paix Lech Walesa a vu le jour dans cette splendide cité. Pour vous, restez simple, naissez à Lodz.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 22."),
   new livre(99,  2, 0, 0,-10, "16. Comment arrivez-vous à croire tout ce qui se répète dans les feuilles de chou hebdomadaires et à sensation? Etudiez plutôt les biographie de vos idoles!\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 2."),
   new livre(98, 10,  0, 0, 0, "17. Désireux de calmer le jeu, vous invitez quelques anciens de chez Commodore dans une nouvelle entreprise: Tramiel Technology Limited (T2L). C'est là que Shiraz Shivji, votre ingénieur numéro 1, développe les bases d'un micro-ordinateur basé sur le 68000 de Motorola.\nRendez-vous au 10."),
   new livre(24, 38, 17, 0, 0, "18. À la tête de plusieurs dizaines de millions de dollars,\n\n1 - partez-vous en retraite à 56 ans (>>24),\n2 - rachetez-vous Atari (>>38)\n3 - ou fondez-vous une nouvelle société (>>17) ?"),
   new livre(11, 32, 0, 0,  0, "19. Voilà un investissement judicieux! Dans les rangs des ingénieurs, vous découvrez Chuck Peddle, le concepteur du microprocesseur 6502.\n\n1 - Accédez-vous à ses demandes de salaires exorbitantes (>>11)\n2 - ou le virez-vous (>>32) ?"),
   new livre(99, 48, 0, 0,-10, "20. Loin d'ignorer le marché américain, vous préférez l'approvisionner régulièrement de matériels européens en rachetant ses fournisseurs.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 48."),

   new livre(49, 35,  0, 0, 0, "21. Après deux années consacrées à votre activité artisanale dans le cadre de l'armée, une promotion vous est proposée.\n\n1 - Reprenez-vous votre liberté (>>49)\n2 - ou rempilez-vous (>>35) ?"),
   new livre(29, 43, 36, 0, 0, "22. Né à Lodz en 1928, vous jouissez d'une enfance aussi heureuse que peut l'être celle d'un petit juif à la veille de la seconde guerre mondiale. Comme la quasi totalité de la population juive de la ville, vous êtes déporté dans un camp de concentration. À Auschwitz,\n\n1 - rencontrez-vous votre future femme (>>29),\n2 - voyez-vous mourir votre mère (>>43)\n3 - ou vous évadez-vous en 1944 (>>36) ?"),
   new livre(99, 37, 0, 0,-10, "23. Vous êtes américain et dans l'âme et dans la réussite de votre carrière. Pourtant, vos goût musicaux vous portent irrésistiblement vers l'Europe et sa culture ancestrale.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 37."),
   new livre(17, 38, 0, 0,-10, "24. Bien que l'envie ne vous manque pas de quitter le business, vous estimez pouvoir vous amuser un peu encore dans le monde des affaires.\nVotre indice de Tramielitude chute de 10.\n\n1 - Fondez-vous une nouvelle société (>>17)\n2 - ou achetez-vous Atari (>>38) ?"),
   new livre(46, 39, 0, 0,  0, "25. 1984. L'action frise les 60$ en bourse, alora qu'elle était partie de 3$. Vous roulez sur l'or, même si vous ne possédez pas la majorité des parts de Commodore Business Machines (CBM... votre clin d'œil à IBM), Irving Gould, le big boss, et vous n'arrivez pas à vous mettre d'accord sur les emplois à offrir à vos fils.\n\n1 - Etes-vous viré (>>46)\n2 - ou partez-vous (>>39) ?"),
   new livre(99, 33, 0, 0,-10, "26. Bien que l'envie ne vous manque pas, vous abandonnez rapidement l'idée de racheter le géant texan de l'électronique.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 33."),
   new livre(34, 20, 0, 0,  0, "27. Là encore, votre \"pif\" fonctionne impeccablement: les bénéfices s'accumulent plus vite que vous ne pouvez les dépenser. Souscieux de bien asseoir Commodore, vous investissez de nouveau.\n\n1 - Mais le faites-vous en France (>>34)\n2 - ou aux États-Unis (>>20) ?"),
   new livre(98,  6, 0, 0,  0, "28. Jouer les chauffeurs à travers New York ne vous enchante guère. Du coup, vous continuez à rechercher un emploi dans vos cordes et finissez par le trouver. Accumulant les économies, vous fondez votre propre boutique, préférant diriger qu'être dirigé!\nRendez-vous au 6."),
   new livre(50, 14, 7, 0,  0, "29. Lorsque les Américains arrivent à Auschwitz en 1945, ils découvrent un chantier d'où 970 silhouettes squelettiques émergent. Parmi celles-ci, vous, votre mère et votre future. Profitant de la présence des Américains, vous quittez le camp pour les États-Unis en 1947. À votre arrivée à New-York,\n\n1 - vendez-vous des journeaux (>>50),\n2 - demandez-vous votre naturalisation (>>14)\n3 - ou entrez-vous dans l'armée (>>7) ?"),
   new livre(98,  3, 0, 0,  0, "30. Ah! les voitures... Quel splendide objet. Il vous fait frissonner de père en fils! Vos trois gamins s'amusent avec leurs Ferrari. Vous préférez le confort des Rolls Royce... et pour la frime votre Morgan vous amuse particulièrement. Dommage qu'elle reste en Angleterre, les Ponts et Chaussées californiens refusant de la voir circuler sur leurs routes.\nRendez-vous au 3."),

   new livre(99, 45, 0, 0,-10, "31. En mettant 50 millions de dollars dans la balance, plus les petites économies de vos trois fistons, vous ne laissez pas la majorité de chez Atari vous échapper.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 45."),
   new livre(99, 11, 0, 0,-10, "32. Et non! Vous ne laissez pas un spécialiste de cette envergure s'échapper, d'autant qu'une jeune société du nom d'Apple aimerait bien se l'approprier.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 11."),
   new livre(19, 47, 0, 0,  0, "33. Partisan d'attaquer pour mieux vous défendre, vous envisagez de nombreuses solutions. Un seul leitmotiv vous soutient: Texas paiera un jour pour sa traîtrise! Pour vous fournir en composants,\n\n1 - rachetez-vous MOS Technology (>>19)\n2 - ou Motorola (>>47) ?"),
   new livre(98, 48, 0, 0,  0, "34. Vous aimez posséder pour mieux contrôles. Vous rachetez deux usines de construction d'additionneuses, l'une dans le nord de la France, l'autre en Allemagne de l'Ouest.\nRendez-vous au 48."),
   new livre(99, 49, 0, 0,-10, "35. Loin d'être antimilitariste, vous estimez avoir sacrifié suffisamment de temps à la banière étoilée. Vous préférez mettre à l'épreuve sur le terrain votre expérience de réparateur.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 49."),
   new livre(99, 29, 0, 0,-10, "36. Loin de ne pas penser à l'évasion, vous patientez, rêvant d'un avenir meilleur en compagnie de la jeune fille que vous apercevez tous les jours.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 29."),
   new livre(97,  0, 0, 0,  0, "37. Doté d'une belle voix (d'un bel organe disent certains) vous chantez volontiers quelques airs, extraits d'opéras ou du folklore polonais ou russe, vos musiques préférées.\nRendez-vous à FIN."),
   new livre(99, 17, 0, 0,-10, "38. Acheter Atari ? En voilà une belle idée... Dommage que la société ne soit pas encore à vendre en ce début d'année 84.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 17."),
   new livre(98, 18, 0, 0,  0, "39. La version officielle, celle que vous cautionnez, insiste sur votre départ volontaire de Commodore. Vous en profitez pour revendre vos actions et tirez une montagne fabuleuse de dollars de l'opération. Vous êtes un vrai millionnaire!\nRendez-vous au 18."),
   new livre(98,  4, 0, 0,  0, "40. La vente des usines européennes vous apporte de quoi développer de nouveaux matériels: les premièrs calculettes électroniques. Le prix des composants de Texas Instruments laisse suffisamment de marge pour rendre les engins accessibles à tous... Ou presque. Vous installez même une unité de production dans le sud de la France pour inonder l'Europe de la célèbre calculette.\nRendez-vous au 4."),

   new livre(99, 27, 0, 0,-10, "41. Doté d'un flair hors du commun et d'une volonté de diffuser les nouvelles technologies au plus grand nombres, vous choisissez d'exporter des machines à écrire portables (d'où le nom) vers l'Europe, mais ce n'est pas l'essentiel de votre activité, plutôt orientée vers l'importation des additionneuses.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 27."),
   new livre(99, 28, 0, 0,-10, "42. Les réparateurs de machines à écrire ne sont pas si demandés qu'il n'y paraît et vous souhaitez rester à New York. Vous embarquez donc à bord d'un taxi comme chauffeur.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 28."),
   new livre(99, 29, 0, 0,-10, "43. Votre mère échappe au massacre et coule des jours heureux en Californie, auprès de son fils. En revanche, votre père subit le sort des innombrables juifs décimés dans les camps de la mort.\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 29."),
   new livre( 9, 30, 0, 0,-10, "44. Même si vous êtes un habitué de certains cercles de jeux de Las Vegas, vos fils ne suivent qu'avec une certaine réticence.\nVotre indice de Tramielitude chute de 10.\nNon, votre passion à tous se trouve ailleurs:\n\n1 - les maisons (>>9)\n2 - ou les bagnoles (>>30) ?"),
   new livre( 2, 16, 0, 0,  0, "45. Vous disposez, avec vos fils, de 53% du capital de la société Atari. D'ailleurs, ces trois garnements s'arrogent les meilleurs places du conseil d'administration. Certains prétendent pourtant qu'ils sont incapables.\n\n1 - Vos fils ont-ils étudié (>>2)\n2 - ou sont-ils autodidactes (>>16) ?"),
   new livre(98, 18, 0, 0,  0, "46. Comme le prétendent certains journaux, comme l'HHHHebo, Irving Gould vous jette comme un malpropre. Vous en profitez pour revendre vos actions et tirez une montagne fabuleuse de dollars de l'opération. Vous êtes un vrai millionnaire!\nRendez-vous au 18."),
   new livre(99, 19, 0, 0,-10, "47. Vous prenez vos désirs pour des réalités! Motorola dépasse déjà largement vos capacités de financement. En revanche, la petite société MOS Technology rassemble des atouts certains et tentateurs!\nVotre indice de Tramielitude chute de 10.\nRendez-vous au 19."),
   new livre(40,  5, 0, 0,  0, "48. Vos invertissements en Europe s'avèrent fructueux: de deux entreprises en déroute vous faites deux fournisseurs sûrs.\n\n1 - Continuez-vous votre développement aux USA (>>40)\n2 - ou en Europe (>>5) ?"),
   new livre(42, 28, 0, 0,  0, "49. Enfin libre! New York vous attire de ses feux enchanteurs. Mais avant de dépenser de l'argent, encore faut-il le gagner!\n\n1 - Devenez-vous réparateur (>>42)\n2 - ou débutez-vous comme chauffeur de taxi (>>28)?"),
   new livre(99 , 7, 0, 0,-10, "50. Agé des dix-huit ans, vous ne connaissez pas le moindre métier en dehors de la survie, une qualité plus appréciée dans l'armée que sur les trottoirs de New York.\nVotre indice de Tramielitude chute de 10. (>>7.")
};
string FIN = "Vous venez de terminer votre carrière à la Tramiel. Votre Indice de Tramielitude (IT) a dû subir quelques revers. Veuillez trouver ci-dessous votre niveau de fidélité au récit.";
string[,] résultat = {
   { "IT entre 100 et 90", "Vous êtes indéniablement un Tramiel en herbe. Vous fuyez les mauvaises décisions comme les plans foireux et n'hésitez pas à changer de voie au bon moment. Une telle réussite ne mérite qu'un mot: Bravo!"},
   { "IT entre 90 et 60", "Vous avez de l'esprit Tramiel entre les oreilles. Avec un poil d'entraînement (pas dans la main), vous devriez suivre l'exemple du Maître sans difficulté."},
   { "IT entre 60 et 30", "De temps à autre, vous arrivez à imiter Tramiel, comme le chimpanzé maladroit tente de peindre la Joconde dans le style de Léonardo da Vinci. Vous me la refaites tout de suite, cette vie, ça ira beaucoup mieux après!"},
   { "IT inférieur à 30", "Catastrophe! La vie trépidante du héros vous est totalement étrangère... Vérifiez que vous tenez bien ce magazine dans le bon sens et recommencez jusqu'à la réussite!"}
};
string solTexte = "Solution: eh oui! Il existe un parcours idéal pour suivre à la trace les aventures de Jack Tramiel. Les plus rusés, les plus imprégnés de la vie de cette figure de la micro-informatique l'auront découvert. Pour les autres, ceux qui renoncent, le voici:";
string solNombre = "1, 22, 29, 7, 21, 49, 28, 6, 13, 27, 34, 48, 40, 4, 33, 19, 11, 25, 46 ou 39, 18, 17, 10, 45, 2, 30, 3 et 37.";
bool solPrems = true;
// int consoleLargeur = Console.WindowWidth;
int index = 1;
int choix = 0;
int score = 100;
int largLigne = 55;
string séparation = SépCréation('*', largLigne);
byte choixMax;


// string toto;////////////////////////////////////////////test qualité
// foreach (livre val in tramiel) {
//    if (val.choix1 == 99) toto = "BAD";
//    else if (val.choix1 == 98) toto = "BON";
//    else toto = "CHOIX";
//    print($"{val.texte}\n");
//    print($"{toto}    -{val.choix1}-    -{val.choix2}-    -{val.choix3}-    -{val.choix4}-    point:{val.point} \n");
//    print("----------------------------------------------------------------\n");
//    Console.ReadLine();
// }

/////////////////////////////////faire un mode debug où l'on n'affiche pas les >>12  >>38 .... en fin de choix, n'y les numéro de paragraphe
CoulBack.Sauve();
Console.Clear();

Console.BackgroundColor = ConsoleColor.Black;
Konzolo.Affiche($"{SépCréation(' ', largLigne)}\n");
Konzolo.Affiche($"{AfficheCentré("MY NAME IS TRAMIEL", largLigne)}\n");
Konzolo.Affiche($"{AfficheCentré("JACK TRAMIEL...", largLigne)}\n");
Konzolo.Affiche($"{SépCréation(' ', largLigne)}\n\n");

Console.BackgroundColor = ConsoleColor.DarkMagenta;
Konzolo.Couleur("blanc");
Konzolo.Affiche($"{printL(intro, largLigne)}\n\n");
Konzolo.Attendre();
Konzolo.Affiche($"{printL(régle, largLigne)}\n\n");
Konzolo.Attendre();
Konzolo.Affiche($"{séparation}\n\n\n");

do {
   if(score>0) score += tramiel[index].point;
   Konzolo.Affiche($"{printL(tramiel[index].texte, largLigne)}\n");
   AfficheScore($"Indice de Tramielitude: {score}points  ", largLigne);

   if (tramiel[index].choix1 == 99) {  AfficheVoie("rouge", largLigne);  index = tramiel[index].choix2;   }
   else if (tramiel[index].choix1 == 98)  {   Konzolo.Attendre();    index = tramiel[index].choix2;   }
   else if (tramiel[index].choix1 == 97)  {   break;  }
   else {
      choixMax = 0;
      if (tramiel[index].choix1 != 0) choixMax++;
      if (tramiel[index].choix2 != 0) choixMax++;
      if (tramiel[index].choix3 != 0) choixMax++;
      if (tramiel[index].choix4 != 0) choixMax++;
      do {
         while(!Konzolo.LireInt36("Tramiel a choisi: ", ref choix));
         if (choix == -1) {
            if (solPrems) {  Konzolo.Affiche($"{printL(solTexte,largLigne)}\n", "grispale"); solPrems = false;  }
            Konzolo.Affiche($"{printL(solNombre, largLigne)}\n", "grispale");
            Konzolo.Couleur("blanc");
         }
      } while (choix<=0 || choix>choixMax);
      switch (choix) {
         case 1: index = tramiel[index].choix1; break;
         case 2: index = tramiel[index].choix2; break;
         case 3: index = tramiel[index].choix3; break;
         case 4: index = tramiel[index].choix4; break;
      }
   }
   Konzolo.Affiche($"{séparation}\n\n\n");
} while (true);

Konzolo.Attendre();
Konzolo.Affiche($"{séparation}\n\n\n");
Konzolo.Affiche($"{printL(FIN, largLigne)}\n\n");
byte résID = 0;   string coulRés = "";
if (score >= 90) {  résID = 0;   coulRés = "vert";  }
if (score < 90  && score >= 60) {   résID = 1;   coulRés = "cyan";   }
if (score < 60  && score >= 30) {   résID = 2;   coulRés = "jaune";   }
if (score < 30) {    résID = 3;    coulRés = "rouge";    }
Konzolo.Couleur(coulRés, true);
Konzolo.Affiche($"{AfficheCentré(résultat[résID,0], largLigne)}\n", "noir");
CoulBack.Restaure();
Konzolo.Affiche($"{printL(résultat[résID,1], largLigne)}\n\n", "blanc");
Konzolo.Affiche($"© TILT Hors Série Numéro 8 - Match ST/Amiga - Mars 1988\n", "grispale");
Konzolo.Affiche($"pages: 34, 35, 36 et 38.\n");
Konzolo.Affiche($"https://www.abandonware-magazines.org/affiche_mag.php?mag=28&num=383\n");
CoulBack.Restaure();


// foreach(livre val in tramiel) {     //testage du texte
//    Konzolo.Affiche($"123456789_123456789_123456789_123456789_123456789_123456789_123456789_123456789\n");
//    Console.WriteLine($"{printL(val.texte, 55)}");
//    Console.WriteLine($"{val.choix1} - {val.choix2} - {val.choix3} - {val.choix4} - points:{val.point}\n");
//    Console.ReadLine();
// }
string SépCréation(char carac, int L){
   string retournationage = "";
   for (int i=0; i<L; i++) retournationage += carac;
   return retournationage;
}

string AfficheCentré(string chaineO, int L, char carac = ' '){
   int nbSpace = (L - chaineO.Length) / 2;
   string chaineD = "";
   string spaceChaine = "";
   for(int i=0; i<nbSpace; i++) spaceChaine += carac;
   chaineD = spaceChaine+chaineO+spaceChaine;
   if (chaineD.Length < L) chaineD += carac;
   return chaineD;
}

void AfficheVoie(string couleur, int L){
   string message = Voie.GénPross();
   CoulBack.Change(couleur, ConsoleColor.Black);
   Konzolo.Affiche($"{AfficheCentré(message, L)}\n");
   CoulBack.Restaure();
   Konzolo.Attendre(); 
}

void AfficheScore(string score, int L) {
   int longMess = score.Length;
   string toto = "";
   for(int i=0; i<(L-longMess); i++) toto += " ";
   CoulBack.Change("jaune", ConsoleColor.Black);
   Konzolo.Affiche($"{toto}{score}\n");
   CoulBack.Restaure();
}

string RemplaceChar(string chaineA, char carac, int pos) {
   StringBuilder chaineB = new StringBuilder(chaineA);
   if (pos>=chaineA.Length || pos<0)  return "";
   else {  chaineB[pos] = carac;  chaineA = chaineB.ToString();   return chaineA;   }
}

string printL(string chaineO, int larg) {
   int iSpaceAv=0, iSpaceAp=0;
   int deltaAV=0, deltaAp=0;
   int iInsére=0, nextLarg = larg;
   string chaineR = chaineO;

   for (int i=0; i<chaineO.Length; i++) {
      if (chaineO[i] == '\n') {   iSpaceAv = i;    iSpaceAp = i;   nextLarg = larg + i;    }
      if (chaineO[i] == ' ')  {
         iSpaceAv = iSpaceAp; iSpaceAp = i;
         if (iSpaceAp >= nextLarg) {
            deltaAp = iSpaceAp - nextLarg;
            deltaAV = nextLarg - iSpaceAv;
            iInsére = (deltaAp < deltaAV) ? iSpaceAp : iSpaceAv ;
            chaineR = RemplaceChar(chaineR, '\n', iInsére);
            nextLarg = larg + iInsére;
         }
      }
   }
   return chaineR;
}

struct livre {
   public string texte;
   public byte choix1;
   public byte choix2;
   public byte choix3;
   public byte choix4;
   public sbyte point;
   public livre(byte C1, byte C2, byte C3, byte C4, sbyte P, string T) {
      texte = T;     //le paragraphe
      choix1 = C1;   //choix numéro 1, si 99 alors redirection auto vers le choix numéro 2
      choix2 = C2;   //choix numéro 2
      choix3 = C3;   //choix numéro 3
      choix4 = C4;   //choix numéro 4, jamais utilisé, juste au cazou
      point = P;     //le nombre de point retranché si mauvais choix, sinon 0
   }
}

static class Voie{
   static Random hazard = new Random();
   static byte ID = 0;
   static string[] mauvaise = {"Jack n'est pas passé par ici.", 
                              "Ce n'est pas comme cela que l'on devient une légende.", 
                              "C'est une mauvaise réponse.", 
                              "Jack a été plus malin que vous sur ce coup."   };
   public static string GénPross(){
      byte IDnew;
      while (true) {
         IDnew = (byte)hazard.Next(0, mauvaise.Length);
         if (ID != IDnew) {  ID = IDnew; break;  }
      }
      return mauvaise[ID];
   }
}

static class CoulBack{
   static ConsoleColor défautBack;
   static ConsoleColor défautForg;

   public static void Change(string text, ConsoleColor fond){
      Konzolo.Couleur(text);    Console.BackgroundColor = fond;   }
   public static void Restaure(){
      Console.ForegroundColor = défautForg;   Console.BackgroundColor = défautBack;   }
   public static void Sauve(){
      défautBack = Console.BackgroundColor;   défautForg = Console.ForegroundColor;   }
}



