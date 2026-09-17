FROM ubuntu:latest

RUN apt-get update \
    && apt-get install -y cowsay

COPY ./cat.cow /usr/share/cowsay/cows

ENTRYPOINT ["/usr/games/cowsay", "-f", "cat.cow"]

CMD ["Miauu"]
