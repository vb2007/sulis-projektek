<?php
use Budapest\Transport\TramLine;
?>
<form action="index.php" method="GET" class="mb-4 p-4 bg-gray-50 rounded-lg border border-gray-300">
    <div class="flex flex-wrap gap-4 items-end">
        <div class="flex flex-col">
            <label for="terminus" class="text-sm font-medium mb-1">Végállomás</label>
            <input type="text" name="terminus" id="terminus" class="border border-gray-300 rounded px-2 py-1" value="<?= htmlspecialchars($_GET['terminus'] ?? '') ?>">
        </div>
        <div class="flex flex-col">
            <label for="interconnected" class="text-sm font-medium mb-1">Fonódó hálózat</label>
            <select name="interconnected" id="interconnected" class="border border-gray-300 rounded px-2 py-1">
                <option value="">Válasszon</option>
                <?php foreach (TramLine::getInterconnecteds() as $key => $value): ?>
                    <option value="<?= htmlspecialchars($key) ?>" <?= (isset($_GET['interconnected']) && $_GET['interconnected'] === $key) ? 'selected' : '' ?>><?= htmlspecialchars($value) ?></option>
                <?php endforeach; ?>
            </select>
        </div>
        <div class="flex flex-col">
            <label for="since" class="text-sm font-medium mb-1">Először üzemben</label>
            <input type="number" name="since" id="since" class="border border-gray-300 rounded px-2 py-1" value="<?= htmlspecialchars($_GET['since'] ?? '') ?>">
        </div>
        <input type="hidden" name="page" value="<?= htmlspecialchars($page ?? 'grid') ?>">
        <button type="submit" class="bg-black text-white px-4 py-1 rounded hover:bg-gray-800">Szűrés</button>
    </div>
</form>
