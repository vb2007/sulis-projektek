FROM ubuntu:latest

RUN apt update && apt install -y cowsay

COPY fox.cow /usr/share/cowsay/cows/fox.cow

ENTRYPOINT ["/usr/games/cowsay", "-f", "fox.cow"]
CMD ["..."]
