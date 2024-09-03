számítógépek = [['Sinclair Research Ltd.', 'ZX Spectrum', 48, 1982],  
                ['Commodore', 'C64', 64, 1982],  
                ['Sinclair Research Ltd.', 'ZX Spectrum+', 48, 1984],  
                ['Commodore', 'PET 2001', 4, 1977],  
                ['Commodore', 'C16', 16, 1984],  
                ['Commodore', 'Amiga 500', 512, 1987],  
                ['Sinclair Research Ltd.', 'ZX Spectrum 128', 128, 1985]]

print("Hány számítógépünk van? ")
print(len(számítógépek))
print("\n")

print("Mikor készült a listában elsőként szereplő gép?")
print(számítógépek[0][-1])
print("\n")

print("Mi a neve a listában szereplő utolsó gépnek?")
print(számítógépek[-1][0])
print("\n")

print("Írjuk ki a neveket és a memóriaméreteket a felsorolás sorrendjében!")
for computer in sorted(számítógépek, key=lambda x: x[-1]):
    print(f"Név:{computer[0]} {computer[1]}\tMemória:{computer[3]}")
print("\n")

print("Írjuk ki azoknak a neveit, amelyek a Commodore cég termékei!")
print()
for computer in számítógépek:
    if computer[0] == "Commodore":
        print(computer[0], computer[1])
print("\n")

print("Gyűjtsük listába azok neveit, amelyek a '80-as években készültek!")
print()
eighties_computers = [computer for computer in számítógépek if 1980 <= computer[-1] < 1990]

print("\n")

print("Írjuk ki a listát, vesszővel felsorolva az elemeket!")
print(*[f"{computer[0]} {computer[1]} {computer[3]}" for computer in eighties_computers], sep=", ")
print("\n")

print("Mennyi memóriájuk van összesen?")
total_memory = sum([computer[2] for computer in számítógépek])
print(f"Összesített memória: {total_memory}.")
print("\n")