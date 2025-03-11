szo = str(input("Kérem adjon meg egy szót: "))

#írja ki a hosszát
print(f"A szó hossza: {len(szo)}")

#írja ki nagybetűsen
print(f"A szó nagybetűsen: {szo.upper()}")

#írja ki kisbetűsen
print(f"A szó kisbetűsen: {szo.lower()}")

#írja ki a kisbetűt nagynak, a nagyot kicsinek
print(f"A szó kis- és nagybetűsen: {szo.swapcase()}")

#mentse el fordítva és írja ki
forditott = szo[::-1]
print(f"A szó fordított sorrendben: {forditott}")
if szo == szo[::-1]:
    print("\t A szó palindrom.")
else:
    print("\tA szó nem palindrom szó.")
