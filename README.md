# YouTube Player

YouTube Player als UWP-Beispiel auf der Xbox One. Das Projekt ist als überschaubares Lernbeispiel für C#, UWP und die Bereitstellung auf einer Xbox One gedacht.

## Tutorial

Die vollständige Schrittfolge mit Hinweisen zu Visual Studio, Developer Mode und Gamepad-Eingabe steht im [XboxDev-Tutorial](https://xboxdev.com/tutorials/xbox-uwp-example-youtube-player/).

## Voraussetzungen

- Windows mit Visual Studio und installierter **Universal Windows Platform development**-Workload
- Eine Xbox One im Developer Mode oder der UWP-Simulator
- Visual Studio-Konfiguration **Debug**, Plattform **x64**

## Projekt öffnen und starten

1. Repository klonen oder als ZIP laden: [example-youtube-player](https://github.com/XboxDevCom/example-youtube-player).
2. **XboxDev - Youtube Player - UWP.sln** in Visual Studio öffnen.
3. **x64** als Plattform auswählen. Für lokale Tests genügt der Simulator; für die Konsole **Remote Machine** wählen, die Xbox-IP eintragen und den Pairing-PIN aus dem Developer Portal bestätigen.
4. Mit **Erstellen** kompilieren und mit **Bereitstellen** auf Simulator oder Konsole starten.
5. Änderungen zunächst an einer kleinen Oberfläche oder einer einzelnen Spielregel testen. Das erleichtert die Fehlersuche auf dem TV-Layout.

## Projektaufbau

Der zentrale Quellcode liegt im Ordner **XboxDev - Youtube Player - UWP/**. Die Solution bündelt das UWP-Projekt und die benötigten Assets. Öffne zuerst `MainPage.xaml` beziehungsweise die dort verwendete Startseite und verfolge anschließend die zugehörige C#-Code-behind-Datei. So lässt sich nachvollziehen, wie Oberfläche, Eingabe und Zustand zusammenspielen.

### Gute erste Änderungen

Zeigt den Aufbau eines einfachen WebView-basierten Videoplayers. Externe Webinhalte können sich unabhängig vom Quellcode ändern. Ändere danach Farben, Texte oder ein Asset und prüfe die Bereitstellung erneut. Bei Spielen sind zusätzlich Fokusführung, Controller-Eingaben und ein lesbares Layout aus größerer Entfernung wichtig.

## Hinweise

Die Beispiele stammen aus der UWP- und Xbox-One-Entwicklungsphase. Für neue Projekte sollte geprüft werden, ob Windows App SDK oder Xbox GDK besser passt. Das Repository zeigt bewusst einen kleinen, nachvollziehbaren Einstieg und ist kein fertiges Produkt.

## Lizenz

Die Lizenzbedingungen stehen in der Datei [LICENSE](LICENSE).
