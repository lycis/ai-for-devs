# Bildfolien: nächste Tokens

Erzeugt mit dem integrierten Imagegen-Werkzeug. Die Prozentwerte sind didaktisch erfunden, keine Messwerte. Die Diagramme zeigen Greedy Decoding mit vereinfachter Tokenisierung.

## next-token-text.png

```text
Create a polished German educational infographic, landscape 16:9, for a developer training slide. White-ish background #f8fafc, navy #102a43 typography, teal #126b75 emphasis, Segoe UI-like sans serif, very large clear labels, restrained flat design, no decorative art. Diagram only, no slide title or footer. Left third: label "Eingabe" and large text "Der Himmel ist …". Middle to right: label "Mögliche nächste Tokens" with four horizontal probability bars, accurately proportional lengths relative to a common scale: "blau" 60 %, "grau" 25 %, "bewölkt" 10 %, "Andere" 5 %. The 60% bar is teal and strongly highlighted, other bars pale blue-gray. A clear connecting arrow from input to distribution. Below the bars a teal arrow from winning blue/blau row to a large result "Der Himmel ist blau" with the appended word blau teal. Label result "Greedy Decoding: höchste Wahrscheinlichkeit". Leave generous space. Bottom small but readable note: "Illustrative Werte · Tokenisierung vereinfacht · Sampling kann anders wählen". All text verbatim and correctly spelled. Show just one prediction step; don't depict vectors or the architecture. Probabilities are invented for teaching, not real measured data.
```

## next-token-code.png

```text
Create a polished German educational infographic, landscape 16:9, for a developer training slide. Background #f8fafc, navy #102a43 typography, teal #126b75 emphasis, Segoe UI-like sans serif with Consolas-like code. Very large readable labels, restrained flat design, no decorative art, no slide title/footer. Left third heading "Eingabe" and monospaced code on two lines "if (user == null)" and "{". A right arrow leads to heading "Mögliche nächste Tokens". Four candidate rows with horizontal bars proportional to percentages: "return" 55 %, "throw" 30 %, "logger" 10 %, "Andere" 5 %. Highlight return and 55% in teal, other bars pale blue-gray. Make 30% bar approximately 55% as long as the 55% bar, 10% bar 18% as long, 5% bar 9% as long. Clear teal connecting arrow from winning row to result area below. Result heading "Greedy Decoding: höchste Wahrscheinlichkeit". Result code on three lines: "if (user == null)" then "{" then "    return". Render return in teal. Deliberately incomplete code: do NOT add semicolon, closing brace, return value, or any more tokens. Below code label "Danach folgt der nächste Vorhersageschritt." Small readable bottom note "Illustrative Werte · Tokenisierung vereinfacht · Sampling kann anders wählen". All text exact. Show one token choice, not probability of whole code snippets. No vectors, robots, architecture or icons.
```
