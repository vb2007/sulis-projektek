set dotenv-load := true
set quiet := false

default:
    @just --list

setup-volumes:
	@docker volume inspect shared_pnpm >/dev/null 2>&1 || docker volume create shared_pnpm
	@docker volume inspect shared_composer >/dev/null 2>&1 || docker volume create shared_composer

ensure-env:
	@test -f .env || cp .env.example .env

frontend-init: setup-volumes ensure-env
	@docker run --rm \
		-v "$(pwd)/frontend:/app" \
		-v "shared_pnpm:/home/node/.pnpm-store" \
		--entrypoint pnpm idomi27/vue:2627 install --frozen-lockfile

responsive-init: setup-volumes ensure-env
	@docker run --rm \
		-v "$(pwd)/frontend:/app" \
		-v "shared_pnpm:/home/node/.pnpm-store" \
		--entrypoint pnpm idomi27/vue:2627 install --frozen-lockfile

backend-init: setup-volumes ensure-env
    @docker compose exec backend composer install --no-interaction --prefer-dist --no-progress
    @docker compose exec backend sh -c 'grep -qE "^APP_KEY=.+$" .env || php artisan key:generate'

run-migrations SEED="":
    @if [ -n "{{SEED}}" ]; then \
        docker compose exec backend php artisan migrate:fresh --seed; \
    else \
        docker compose exec backend php artisan migrate; \
    fi
    
# Initialize project
[arg('FLAGS', pattern='^(--seed|-s)( (--seed|-s))*$')]
init *FLAGS: frontend-init responsive-init
    docker compose up -d
    just backend-init
    just run-migrations {{FLAGS}}

# Start project
start *ARGS:
    docker compose up -d  {{ARGS}}

# Restart service(s)
restart *ARGS:
    docker compose restart {{ARGS}}

# Stop service(s)
stop *ARGS:
    docker compose stop {{ARGS}}

# Remove service(s)
down *ARGS:
    docker compose down {{ARGS}}

# Start frontend only
frontend *ARGS: frontend-init
    docker compose up -d frontend proxy {{ARGS}}

# Start responsive only
responsive *ARGS: responsive-init
    docker compose up -d responsive proxy {{ARGS}}

# Start backend only
backend SEED="" *ARGS: setup-volumes ensure-env
    docker compose up -d backend webserver {{ARGS}}
    just backend-init
    just run-migrations "{{SEED}}"

# Start jsonserver  only
jsonserver *ARGS: ensure-env setup-volumes
    docker compose up -d jsonserver proxy {{ARGS}}

# Start database only
db *ARGS: ensure-env setup-volumes
    docker compose up -d db phpmyadmin {{ARGS}}