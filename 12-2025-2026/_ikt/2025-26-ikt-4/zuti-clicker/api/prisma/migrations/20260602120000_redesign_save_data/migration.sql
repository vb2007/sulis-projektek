-- Drop old flat save table
DROP TABLE IF EXISTS `SaveData`;

-- CreateTable GameSave
CREATE TABLE `GameSave` (
    `id`                INTEGER NOT NULL AUTO_INCREMENT,
    `userId`            INTEGER NOT NULL,
    `tokens`            DOUBLE  NOT NULL DEFAULT 0,
    `totalTokensEarned` DOUBLE  NOT NULL DEFAULT 0,
    `totalClicks`       INTEGER NOT NULL DEFAULT 0,
    `elapsedSeconds`    DOUBLE  NOT NULL DEFAULT 0,
    `savedAt`           DATETIME(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    `updatedAt`         DATETIME(3) NOT NULL,

    UNIQUE INDEX `GameSave_userId_key`(`userId`),
    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable UnitSave
CREATE TABLE `UnitSave` (
    `id`         INTEGER      NOT NULL AUTO_INCREMENT,
    `gameSaveId` INTEGER      NOT NULL,
    `unitId`     VARCHAR(32)  NOT NULL,
    `owned`      INTEGER      NOT NULL DEFAULT 0,

    UNIQUE INDEX `UnitSave_gameSaveId_unitId_key`(`gameSaveId`, `unitId`),
    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- AddForeignKey
ALTER TABLE `GameSave` ADD CONSTRAINT `GameSave_userId_fkey`
    FOREIGN KEY (`userId`) REFERENCES `User`(`id`) ON DELETE RESTRICT ON UPDATE CASCADE;

-- AddForeignKey
ALTER TABLE `UnitSave` ADD CONSTRAINT `UnitSave_gameSaveId_fkey`
    FOREIGN KEY (`gameSaveId`) REFERENCES `GameSave`(`id`) ON DELETE CASCADE ON UPDATE CASCADE;
