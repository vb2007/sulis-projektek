<?php
use Budapest\Transport\TramLine; ?>

<form action="index.php" method="GET" class="p-4 rounded-lg">
    <label for="terminus" class="text-sm font-medium">Végállomás</label>
    <input type="text" name="terminus" id="terminus" value="<?= htmlspecialchars(
        $_GET["terminus"] ?? "",
    ) ?>">

    <label for="interconnected" class="text-sm font-medium">Fonódó hálózat</label>
    <select name="interconnected" id="interconnected">
        <option value="">Válasszon</option>
        <?php foreach (TramLine::getInterconnecteds() as $key => $value): ?>
        <option value="<?= htmlspecialchars($key) ?>" <?= isset(
    $_GET["interconnected"],
) && $_GET["interconnected"] === $key
    ? "selected"
    : "" ?>><?= htmlspecialchars($value) ?></option>
        <?php endforeach; ?>
    </select>

    <label for="since" class="text-sm font-medium">Először üzemben</label>
    <input type="number" name="since" id="since" value="<?= htmlspecialchars(
        $_GET["since"] ?? "",
    ) ?>">

    <input type="hidden" name="page" value="<?= htmlspecialchars(
        $page ?? "grid",
    ) ?>">

    <button type="submit">Szűrés</button>
</form>
