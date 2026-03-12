<?php
require_once __DIR__ . "/../data.php";

$selectedId = $_GET["id"] ?? 690;
$selectedWidth = $_GET["width"] ?? 400;
$selectedHeight = $_GET["height"] ?? 320;
$selectedBlur = $_GET["blur"] ?? 0;
$selectedGrayscale = isset($_GET["grayscale"]) ? true : false;
?>

<form method="get">
    <label for="id">Kép kiválasztása</label>
    <select name="id" id="id">
        <?php foreach ($images as $id => $name): ?>
            <option value="<?= $id ?>" <?= $selectedId == $id ? "selected" : "" ?>><?= $name ?></option>
        <?php endforeach; ?>
    </select>

    <label for="width">Szélesség (px)</label>
    <input type="number" name="width" id="width" value="<?= htmlspecialchars($selectedWidth) ?>">

    <label for="height">Magasság (px)</label>
    <input type="number" name="height" id="height" value="<?= htmlspecialchars($selectedHeight) ?>">

    <fieldset>
        <legend>Elmosás mértéke</legend>
        <?php for ($i = 0; $i <= 3; $i++): ?>
            <input type="radio" name="blur" id="blur<?= $i ?>" value="<?= $i ?>" <?= $selectedBlur == $i ? "checked" : "" ?>>
            <label for="blur<?= $i ?>"><?= $i ?></label>
        <?php endfor; ?>
    </fieldset>

    <input type="checkbox" name="grayscale" id="grayscale" <?= $selectedGrayscale ? "checked" : "" ?>>
    <label for="grayscale">Szürkeárnyalatos</label>

    <button type="submit">Generálás</button>
</form>
