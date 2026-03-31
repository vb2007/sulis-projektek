<form method="GET" action="index.php" class="max-w-200 mx-auto">
    <label for="mount">Bajonett</label>
    <input type="text" name="mount" id="mount" maxlength="100" value="<?= htmlspecialchars(
        $mount,
    ) ?>">

    <label for="type">Típus</label>
    <select name="type" id="type">
        <option value="">Válassz...</option>
        <?php foreach (
            \Media\Camera\Lens::getAvailableTypes()
            as $key => $value
        ): ?>
            <option value="<?= $key ?>" <?= $key === $type
    ? "selected"
    : "" ?>><?= $value ?></option>
        <?php endforeach; ?>
    </select>

    <label for="minFocalLength">Minimum gyújtótávolság</label>
    <input type="number" name="minFocalLength" id="minFocalLength" value="<?= htmlspecialchars(
        $minFocalLength,
    ) ?>">

    <input type="submit" value="Szűrés">

    <input type="hidden" name="page" value="<?= htmlspecialchars($page) ?>">
</form>
