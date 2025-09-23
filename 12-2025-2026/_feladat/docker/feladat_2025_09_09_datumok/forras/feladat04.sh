#!/bin/bash

echo "Kérlek várj..."

apt-get update -qq >/dev/null 2>&1 && apt-get install -y tzdata >/dev/null 2>&1

echo -e "\033[104m Beállított régió: \033[49m $TZ \033[49m"
echo -e "\033[42m Pontos idő a megadott régióban: \033[49m $(date "+%Y-%m-%d %H:%M:%S")" 