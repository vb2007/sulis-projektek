# Stage 1: compile to native AOT executable.
FROM dart:stable AS build

WORKDIR /app
COPY pubspec.* ./
RUN dart pub get

COPY . .
RUN dart build cli --target bin/server.dart -o output

# Stage 2: minimal runtime image.
FROM scratch
COPY --from=build /runtime/ /
COPY --from=build /app/output/bundle/ /app/

EXPOSE 3000

# Mount your data directory at /data: docker run -v $(pwd)/data:/data ...
ENV DATA_DIR=/data
ENV PORT=3000

CMD ["/app/bin/server"]
