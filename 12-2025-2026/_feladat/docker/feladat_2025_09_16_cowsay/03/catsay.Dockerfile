FROM ubuntu:latest

RUN apt update && apt install -y cowsay

COPY cat.cow /usr/share/cowsay/cows/cat.cow

ENTRYPOINT ["/usr/games/cowsay", "-f", "cat.cow"]
CMD ["Mi-auu"]
