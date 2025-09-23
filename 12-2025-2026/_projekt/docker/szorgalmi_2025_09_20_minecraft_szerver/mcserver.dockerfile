FROM ubuntu:24.04

WORKDIR /mcserver

RUN apt update && apt install -y --no-install-recommends openjdk-21-jre-headless wget unzip
RUN wget https://piston-data.mojang.com/v1/objects/6bce4ef400e4efaa63a13d5e6f6b500be969ef81/server.jar

COPY TheBlackStoneFortress.zip /mcserver/
RUN unzip /mcserver/TheBlackStoneFortress.zip -d /mcserver/ && rm /mcserver/TheBlackStoneFortress.zip

RUN echo "eula=true" > eula.txt
RUN echo "online-mode=false" > server.properties
RUN echo "level-name=The BlackStone Fortress" >> server.properties

EXPOSE 25565

ENTRYPOINT ["java", "-Xms1024M", "-Xmx1024M", "-jar", "server.jar", "nogui"]
