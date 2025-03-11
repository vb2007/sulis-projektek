def fibonacci(a):
    #n-ig fibonacci számokat generál
    fibonacciLista = [0, 1]
    while fibonacciLista[-1] < a:
        fibonacciLista.append(fibonacciLista[-1] + fibonacciLista[-2])

    #megnézi az n benne van-e a listában
    if a in fibonacciLista:
        return f"A(z) {a} tagja a fibonacci listának."
    else:
        return f"A(z) {a} nem tagja a fibonacci listának."

a = int(input("Adj meg egy számot: "))

print(fibonacci(a))