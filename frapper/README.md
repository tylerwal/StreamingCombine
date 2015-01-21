# Frapper 

#### Minimalist Fmmpeg Wraper for .Net.

## About

[Nuget package](https://www.nuget.org/packages/Frapper)

[Fmmpeg site](http://www.ffmpeg.org/)

## Usage

First, add ffmpeg.exe path to your App.config or Web.config.

    <appSettings>
      <add key="ffmpeg:ExeLocation" value="C:\ffmpeg.exe" />
    </appSettings>

Then:

    using Frapper;

    FFMPEG ffmpeg = new FFMPEG();
    // Get file information :)
    ffmpeg.RunCommand("--i C:\\lol.mp4");

