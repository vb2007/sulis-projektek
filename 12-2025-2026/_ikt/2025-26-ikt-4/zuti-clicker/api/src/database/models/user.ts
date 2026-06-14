import { prisma } from "../prisma";

export const getUserByEmail = async (email: string) => {
  return prisma.user.findUnique({
    where: { email },
    include: { authentication: true }
  });
};

export const getUserByUsername = async (username: string) => {
  return prisma.user.findUnique({
    where: { username },
    include: { authentication: true }
  });
};

export const getUserBySessionToken = async (sessionToken: string) => {
  return prisma.authentication.findFirst({
    where: { sessionToken },
    include: { user: true }
  });
};

export const createUser = async (data: {
  username: string;
  email: string;
  password: string;
  salt: string;
}) => {
  return prisma.user.create({
    data: {
      username: data.username,
      email: data.email,
      authentication: {
        create: {
          password: data.password,
          salt: data.salt,
          sessionToken: ""
        }
      }
    },
    include: { authentication: true }
  });
};

export const updateSessionToken = async (userId: number, sessionToken: string) => {
  return prisma.authentication.update({
    where: { userId },
    data: { sessionToken }
  });
};
