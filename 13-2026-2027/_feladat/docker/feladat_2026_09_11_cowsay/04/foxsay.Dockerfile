FROM ubuntu:latest

RUN apt-get update \
    && apt-get install -y cowsay

COPY ./fox.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "fox.cow"]

CMD ["..."]
