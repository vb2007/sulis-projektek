<form method="GET" action="index.php" class="border-gray-200">
    <input type="hidden" name="page" value="<?= $page ?>">

    <div>
        <label for="manufacturer_id">Gyártó</label>
        <select name="manufacturer_id" id="manufacturer_id">
            <option value="">Válasszon gyártót</option>
            <?php
            $manufacturers = $televisions[0]->getManufacturers();
            foreach ($manufacturers as $id => $name):
                $selected =
                    isset($_GET["manufacturer_id"]) &&
                    $_GET["manufacturer_id"] == $id
                        ? "selected"
                        : ""; ?>
                <option value="<?= $id ?>" <?= $selected ?>><?= $name ?></option>
            <?php
            endforeach;
            ?>
        </select>
    </div>

    <div>
        <label for="minimum_size">Méret (minimum)</label>
        <input type="number" name="minimum_size" id="minimum_size"
               value="<?= $_GET["minimum_size"] ?? "" ?>">
    </div>

    <div>
        <label for="maximum_size">Méret (maximum)</label>
        <input type="number" name="maximum_size" id="maximum_size"
               value="<?= $_GET["maximum_size"] ?? "" ?>">
    </div>

    <div>
        <input type="submit" value="Szűrés">
    </div>
</form>
