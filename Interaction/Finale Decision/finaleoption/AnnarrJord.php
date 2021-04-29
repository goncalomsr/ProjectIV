<!DOCTYPE HTML>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Domine&display=swap" rel="stylesheet">
    <title></title>
    <link rel="stylesheet" href="Stylesheets/style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>
                Annarr j&oumlrd
            </h1>
            <h2>
                Choose the Hero's fate
            </h2>
        </div>
    </header>
    <br />
    <main>
        <div class="description">
            <h3>
                In a distant land, there are four kingdoms living in harmony,
                each, ruled by the elemental leader. A hero of light must fulfill
                his destiny and battle darkness once and for all. But unknowably to him,
                his destiny is in his hands and in the final choice he makes.
            </h3>
        </div>
        <br />
        <div class="buttons">
            <form action="Php/sendoptions.php" method="post">
                <button id="option0" name="option0" value= "0" onclick="alert('Light above all!')">
                Is Light above all and all there is needed?
                </button>

                <button id="option1" name="option1" value="1" onclick="alert('Darkness is necessary!')">
                Is Darkness needed to have balance?
                </button>
            </form>
        </div>
    </main>
</body>
</html>