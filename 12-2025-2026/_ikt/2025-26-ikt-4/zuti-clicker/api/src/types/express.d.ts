declare global {
  namespace Express {
    interface Request {
      identity?: {
        id: number;
        username: string;
        email: string;
        createdAt: Date;
        updatedAt: Date;
      };
    }
  }
}

export {};
