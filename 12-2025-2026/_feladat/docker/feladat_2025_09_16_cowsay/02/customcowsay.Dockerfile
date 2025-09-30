FROM ubuntu:latest

RUN apt update && apt install -y cowsay

ENTRYPOINT ["/usr/games/cowsay"]

CMD ["Milyen csodás ez a nap!"]
