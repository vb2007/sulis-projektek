FROM ubuntu:latest

RUN apt-get update \
    && apt-get install -y cowsay

COPY ./meme.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "meme.cow"]

CMD ["Nigga!"]
