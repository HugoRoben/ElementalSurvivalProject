
# Elemental Survival 
### Hugo Roben 13424718


## Niet te missen dingen bij het beoordelen:
#### In mijn proposal heb ik aangegeven te willen focussen op het grafische design in mijn game, hieronder volgen de dingen die ik in dat opzicht het belangrijkst vindt.
- Blender modellen. De modellen voor de karakters in mijn game heb ik zelf gemaakt. Ik heb het eerste kale lichaam met armature-rig gemaakt via een tutorial, maar daarna ben ik volledig op mezelf verder gegaan. De modellen die in de game te vinden zijn, zijn dus volledig op eigen inzet gemaakt.
- De aanvallen in de game zijn zelf ontworpen. Ik heb de volgende video van Brackeys gebruikt als beginpunt: https://www.youtube.com/watch?v=FEA1wTMJAR0&t=5s. De echte aanvallen heb ik daarna zelf ontworpen en gemaakt. 
- De enemies in het spel lijken, naar mijn mening, uitstekend op de vuur enemies uit de serie. 
- De vlaggen in de arena heb ik zelf ontworpen. Een mooi detail is dat de vlaggen in-game meebewegen, alsof er wind staat in de arena. 
- In de karakterselectie scene staan drie camera's die elke een van de drie karakters filmen. Het beeld van deze camera wordt opgeslagen als render-texture. Hierdoor zijn de karakters tijdens het selecteren in de game groot te zien in beeld. De mini-map in het spel zelf werkt op dezelfde manier.

#### Niet te missen delen uit de code:
- EnemyAi.cs: De code werkt d.m.v. een state machine en meerdere functies die aangeroepen worden tijdens events in de animations. Hierdoor is de code erg goed gestructureerd. 
- WaceSpawner.cs: Dit is de code die er voor zorgt dat er items spawnen waarmee nieuwe aanvallen opgepakt kunnen worden en dat de tegenstanders in golven spawnen in de game. De structuur van de golven is een lijst met rondes, met voor elke ronde een lijst met objecten om te spawnen. De code itereert over de lijst met objecten om te spawenen en kiest hierna willekeurig een van de drie spawnpoints (ook een lijst). Het object spawnt vervolgens binnen een range van het spawnpoint. Ook wordt in deze code het totaal aantal kills van de speler bijgehouden.
- PlayerAnimations.cs: Alhoewel de animaties niet worden bestuurd d.m.v een state machine, maar door een groot aantal if-statements, ben ik trots op de animator die ik uiteindelijk voor de speler heb kunnen maken. De speler kan alle kanten op lopen en sprinten, rollen naar links, rechts en naar voren, en verschillende aanvallen uitvoeren (met verschillende animaties). Als de speler op spatie drukt en tegelijkertijd meerdere WASD knoppen ingedrukt heeft wordt A of D geprioritiseerd over W, en rolt daardoor dus opzij. 
- De compacte structuur van inputManager.cs, MoveCamera.cs en MovePlayer.cs: de drie scripts hebben elk een specifieke eigen functie en voeren dit compact uit. De scripts zijn niet langer dan nodig is en de taken die elk script uitvoert zijn goed gescheiden. 

## Grote Beslissingen.

- In de proposal voor de game heb ik geschreven met vier karakters te kunnen spelen tegen vier verschillende soorten vijanden. Ik heb ervoor gekozen om één enemy te maken: de soldaat van de vuurnatie uit de serie. Ik heb deze beslissing genomen omdat het in de tijd die beschikbaar was voor dit project voor mij niet mogelijk was om acht verschillende karakters te maken. Ik had nog niet erg veel ervaring met blender, dus echt op gang komen in het ontwikkelen van de karakters was moeilijk. Dit is ook wat niet zo handig was aan het vorige ontwerpidee, ik ging er door mijn (geringe) ervaring in blender vanuit dat het modeleren van de karakters soepeler zou verlopen.\
De nieuwe oplossing is beter aangezien er nu goed werkende enemies in de game zitten, omdat ik maar op één enemy hoefde te focussen. Daarnaast is de game nu een stuk accurater over de serie waarop het gebaseerd is. In het plan voor mijn game heb ik gezegd dat de game ontwikkeld werd voor mensen die fan waren/zijn van Avatar: The legens of Aang, doordat de speler nu vecht tegen de tegenstanders uit die serie wordt het gevoel van die serie een stuk beter terug gehaald.\
Ik ben van mening dat nu het project is afgelopen, de beslissing nogsteeds ten goede van de game komt. De game lijkt nu écht een stuk beter op de serie, en dat was een van mijn voornaamste doelen.

- Ik heb gaanderweg besloten om maar twee karakters beschikbaar te maken om mee te spelen, in plaats van vier zoals in mijn oorspronkelijke ontwerp stond. Dit had twee redenen. Allereerst de gelijkenis met de serie. Toen ik had besloten om als enige tegenstanders de vuurnatie soldaten te maken, was het (deels) accurater om niet ook met een vuur-karakter te kunnen spelen. Dit zijn namelijk in het grootste deel van de serie louter vijanden.\
Daarnaast heb ik besloten het water karakter weg te laten. Ik heb dit karakter wel ontworpen, echter is er bij het riggen en weight-painten van het karakter het een en ander fout gegaan, waardoor de karakter niet speelbaar was in de game. Op het moment dat dit gebeurde was de tijd die over was voor de game nog gering. Hierom heb ik ervoor gekozen om deze karakter niet opnieuw te ontwikkelen, en dus te eindigen met twee speelbare karakters.\
Nu het project voorbij is ben ik van mening dat het nogsteeds een goede keuze was om niet een vuur-karakter te maken waar de speler mee kan spelen. Net als in de serie onstaat er nu in de game een besef van de 'goede' elementen tegen de 'slechte' elementen.\
Het water karakter had ik wel erg graag nog af willen maken. De game is completer als echt met alle vier de elementen gespeeld kan worden, in plaat van alleen met aarde en lucht.