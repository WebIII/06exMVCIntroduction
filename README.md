# Oefeningen: Hoofdstuk 6 - BlackJack [Starter Files]

## Opgave
In deze oefening gaan we het BlackJack spel naar een hoger niveau tillen. Waar we vroeger gebruik maakten van een console applicatie, gebruiken we nu MVC. Wat volgt zijn enkele screenshots van het eindresultaat:

## Start Spel
<img src="https://webiii.github.io/docs/H06/fig1.png" alt="start" border="0">

## Player Burned, Dealer Wins.
<img src="https://webiii.github.io/docs/H06/fig2.png" alt="Player-Burned" border="0">

> Player heeft kaart gevraagd (en gekregen) – zijn score is hoger dan 21 en dealer wint. Link om nieuw spel te starten wordt zichtbaar. Card en Pass link zijn niet zichtbaar. 

## Dealer Burned, Player Wins.
<img src="https://webiii.github.io/docs/H06/fig3.png" alt="Dealer-Burned" border="0">

> Player heeft gepassed – zijn score 20, dealer speelt automatisch verder tot hij een gelijke of hogere score heeft dan player (in dit geval 20 of 21). Hij behaalt 22 en player wint. Link om nieuw spel te starten wordt zichtbaar. Card en Pass link zijn niet zichtbaar. 

## BlackJack.
<img src="https://webiii.github.io/docs/H06/fig4.png" alt="Black-Jack" border="0">

> Player heeft BlackJack – er worden geen kaarten meer verdeeld, de player wint.

---

## Voorbereiding

1. Deze repository bevat 3 mappen en BJ.css (css bestand):
    - Images: bevat de afbeeldingen van de kaarten 
    - Models: bevat het domein klassen en Enums (zie hfdst3) 
    - ModelsTest: bevat de Unit testen (zie hfdst 3) 
2. Maak een nieuw project aan. Kies voor C# - Web > ASP.NET Core webapplication. Geef het project de naam BlackJackGame. Kies vervolgens de template **Empty – No Authentication**. 

3.	Voeg toe aan source Control.
 
4. Maak een Models folder aan in het project en kopieer de bestanden uit de models folder in deze repository naar deze folder.
    > Deze zijn identiek aan deze van les 3
 
5. Maak een xUnit test project BlackJackGame.Tests aan zoals in de oefening van les 3. Maak een map Models aan en kopieer de inhoud van de folder ModelsTest naar dit project. Vergeet de referentie naar BlackJackGame niet.  Run de unit testen. Zorg ervoor dat deze allen slagen.

---

## Implementatie van Controller en View voor de Index. 
 1. Configureer in ConfigureServices en Configure methoden van de klasse StartUp.cs: zorg ervoor dat je MVC kan gebruiken, geef de juiste routing mee.  
 
2. Maak een map `Controllers` aan en maak een empty MVC Controller `HomeController.cs` aan met een actie methode `Index` 
    - Maak  een instantie van de klasse `Blackjack` aan en geef dit model door aan de view in de `Index` methode.
 
3. Rechtsklik de methode `Index` > `Add View`. Vink `use a layout page` uit. Dit maakt een map `Views` aan, daarin een map `Home` en de view `Index.cshtml`. 
 
4. In de Index view gaan we de images en css gebruiken 
    - Maak gepaste submappen (css en images) in `wwwroot` en plaats deze static content er in (images folder en BJ.css)
    - Zorg ervoor dat er static files (images-css-…) kunnen gebruikt worden. Pas aan in de `middleware` van de `startup` klasse. 
5. Werk de Index view verder uit  
 
    **Opmerking ivm de images/kaarten**

    - Back.gif : kaart faceDown
    - Overige : bvb. kaart0.gif ... kaart12.gif : harten 1 .... harten koning.  
 
    Het kaartnumer kan je berekenen o.b.v. de enum types:
    ```csharp
    BlackJackCard c;
    int suit = (int)c.Suit; // de waarde uit enum types, voor harten is dit 1  
    int value = (int)c.FaceValue; //1 voor de ace bvb.  
    int kaartnummer = ((suit -1)* 13) + value-1;  
    ```
    
    Je kan Razor een handje helpen als de overgang van C# naar html niet duidelijk is. Gebruik () om aan te duiden welke expressie door Razor geëvalueerd moet worden, bijvoorbeeld: `@(kaartnummer)`.
    
    **Opmerking ivm de css**
    - De status wordt weergegeven in een `h1` tag. Plaats elk hand binnen een `paragraph` met class selector `hand`. Gebruik de class selector `total` voor de weergave van het totaal. Het volledige game wordt weergegeven in een `div` met `id` selector `playGround`. Voor de knoppen worden `hyperlinks` gebruikt.  
    
    - Gebruik voor de links de tag helpers:  voeg bovenaan in de view: 
        ```csharp
        @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers 
        ```
        Voorbeeld voor Next Card:
        ```html
        <a asp-controller="Home" asp-action="NextCard">Next Card</a> 
        ```
 
6. Je moet je programma nu kunnen runnen en de Index moet mooi weergegeven worden 

---


## Implementatie van Controller en View voor NextCard en Pass 
 
1. Deze action methodes zullen ook de Index view retourneren 
2. Denk er aan gebruik te maken van een session 
    - Zorg ervoor dat er session kan gebruikt worden. Pas aan in de middleware. 
    - Maak een extension klasse voor het aanmaken en inlezen van session objecten. 
3. Voor serialisatie en deserialisatie 
- Gebruik OptIn en decoreer alle fields en properties die je wenst te (de)serializeren met het `[JsonProperty]` attribuut 
    - Let op: Tijdens deserialisatie zal `JsonConvert` gebruik maken van de `default constructors`. De default constructors van `Deck` en `Blackjack` bevatten echter logica die we niet wensen uit te voeren bij deserialisatie. Via het attribuut `[JsonConstructor]` kan je aangeven welke constructor gebruikt moet worden bij deserialisatie. Zo kan je een specifieke constructor aanmaken voor deserialisatie. Deze constructor mag `private` zijn.  Daar er reeds een `constructor` is met de default signatuur kunnen we gebruik maken van een dummy parameter om onze nieuwe constructor een unieke signatuur te geven: 
    ```csharp
    [JsonConstructor]
    private BlackJack(bool thisIsForJsonOnly) {

    }
    ```
--- 
## Extra 
1. Maak van de Shuffle methode een extension methode gedefinieerd op `IList<T>`.
 
2. Geef het aantal winnende spelletjes van de dealer en de player weer.
 
 

