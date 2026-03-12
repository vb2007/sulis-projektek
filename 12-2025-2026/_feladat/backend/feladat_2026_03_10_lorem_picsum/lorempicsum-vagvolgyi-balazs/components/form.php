<form method="get">
    <label for="id">Kép kiválasztása</label>
    <select name="id" id="id">
        <?php foreach ($images as $imgId => $name): ?>
            <option value="<?= $imgId ?>" <?= $id == $imgId ? "selected" : "" ?>><?= $name ?></option>
        <?php endforeach; ?>
    </select>

    <label for="width">Szélesség (px)</label>
    <input type="number" name="width" id="width" min="100" value="<?= htmlspecialchars($width) ?>">

    <label for="height">Magasság (px)</label>
    <input type="number" name="height" id="height" min="100" value="<?= htmlspecialchars($height) ?>">

    <fieldset>
        <legend>Elmosás mértéke</legend>
        <?php for ($i = 0; $i <= 3; $i++): ?>
            <input type="radio" name="blur" id="blur<?= $i ?>" value="<?= $i ?>" <?= $blur == $i ? "checked" : "" ?>>
            <label for="blur<?= $i ?>"><?= $i ?></label>
        <?php endfor; ?>
    </fieldset>

    <input type="checkbox" name="grayscale" id="grayscale" <?= $grayscale ? "checked" : "" ?>>
    <label for="grayscale">Szürkeárnyalatos</label>

    <button type="submit">Generálás</button>
</form>
