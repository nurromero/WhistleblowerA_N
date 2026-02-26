Dette projekt er en simpel backend-implementering af en whistleblower løsning med fokus på sikkerhed og anonymitet.

Systemet gør det muligt for brugere at indsende indberetninger anonymt (whistleblowers) og følge status via en sikker tracking token.

**Requirements/funktionelle krav**
- Whistebloweren kan indsende en anonym rapport (titel + beskrivelse)
- Systemet genererer automatisk en unik tracking token.
- Medarbejdere kan slå deres sag op via tracking token for at se om den er submitted, under behandling (under investigation) eller lukket (closed)
- Status styres udelukkende af systemet.
- Løsningen implementeres som REST API.


**Security Requirements/sikkerhedskrav**

- Ingen personlige oplysninger kræves eller gemmes.
- Intern database-ID vises aldrig.
- Tracking token genereres server-side (GUID).
- Status, dato og token kan ikke sættes af klienten.
- Adgang til sag sker udelukkende via tracking token.


**Use-Cases**
- UC1: Indsend rapport
Bruger indsender titel og beskrivelse. Systemet genererer tracking token og returnerer den.
- UC2: Følg status
Bruger indtaster tracking token og får vist status samt oprettelsesdato.


**Misuse-Cases**
- MC1: Gætning af tracking tokens
Undgåes ved brug af GUID som er umulige at gætte
- MC2: Overposting attack
Undgåes ved at adskille API-model (DTO) fra domænemodel.

**Design**
Løsningen er designet med fokus på anonymitet. Bruger kan kun indsende nødvendige oplysninger, og se status ved brug af et unikt trackingtoken senere hen. 

