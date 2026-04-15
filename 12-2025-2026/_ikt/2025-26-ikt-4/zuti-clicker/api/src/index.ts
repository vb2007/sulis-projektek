import express from "express";
import http from "http";
import bodyParser from "body-parser";
import cookieParser from "cookie-parser";
import compression from "compression";
import cors from "cors";
import dotenv from "dotenv";

dotenv.config();

const corsOriginUrls: string[] | undefined = process.env.CORS_ORIGIN_URLS?.split(",");
const corsOptions: cors.CorsOptions = {
  origin: corsOriginUrls,
  credentials: true
};

const app = express();

app.use(cors(corsOptions));
app.use(compression());
app.use(cookieParser());
app.use(bodyParser.json());

const server = http.createServer(app);

const ip: string | undefined = process.env.IP;
const port: string | undefined = process.env.PORT;
server.listen(port, () => {
  console.log(`Express.js server started on http://${ip}:${port}`);
});

// app.use("/", router());
