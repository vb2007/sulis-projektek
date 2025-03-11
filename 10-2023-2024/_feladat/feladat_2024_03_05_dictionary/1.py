#bekéri egy kutya nevét, életkorát, fajtáját, és hogy rendelkezik-e védőoltással egy szótárba. majd a szóárt kiírja
nev = input("Add meg a kutya nevét: ")
kor = int(input("Add meg a kutya életkorát: "))
fajta = input("Add meg a kutya fajtáját: ")
vedooltas = input("Védőoltással rendelkezik-e? (igen/nem): ")

if vedooltas == "igen":
    vedooltas = True
else:
    vedooltas = False

kutya = {
    "nev": nev,
    "kor": kor,
    "fajta": fajta,
    "védőoltás": vedooltas
}

print(kutya)