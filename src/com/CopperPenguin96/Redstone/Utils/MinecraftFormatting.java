package com.CopperPenguin96.Redstone.Utils;

import java.awt.Color;

public enum MinecraftFormatting {
    Black('0'),
        DarkBlue('1'),
        DarkGreen('2'),
        DarkAqua('3'),
        DarkRed('4'),
        DarkPurple('5'),
        Gold('6'),
        Gray('7'),
        DarkGray('8'),
        Blue('9'),
        Green('a'),
        Aqua('b'),
        Red('c'),
        LightPurple('d'),
        Yellow('e'),
        White('f'),

        Bold('l'),
        Underline('n'),
        Italic('o'),
        Magic('k'),
        Strike('m'),
        Reset('r');

    public char Code;

    private MinecraftFormatting(char code) {
        Code = code;
    }

    public final Color toColor() {
    	float[] hsb = Color.RGBtoHSB(toRgb()[0], toRgb()[1], toRgb()[2], null);
    	return Color.getHSBColor(hsb[0], hsb[1], hsb[2]);
    }

    public static String codeToId(String code) {
        return switch (code) {
            case "0" -> "black";
            case "1" -> "dark_blue";
            case "2" -> "dark_green";
            case "3" -> "dark_aqua";
            case "4" -> "dark_red";
            case "5" -> "dark_purple";
            case "6" -> "gold";
            case "7" -> "gray";
            case "8" -> "dark_gray";
            case "9" -> "blue";
            case "a" -> "green";
            case "b" -> "aqua";
            case "c" -> "red";
            case "d" -> "light_purple";
            case "e" -> "yellow";
            default -> "white";
        };
    }

    public static int[] codeToRgb(String code) {
        return switch (code) {
            case "0" -> new int[] {
                0,
                0,
                0
            };
            case "1" -> new int[] {
                0,
                0,
                170
            };
            case "2" -> new int[] {
                0,
                170,
                0
            };
            case "3" -> new int[] {
                0,
                170,
                170
            };
            case "4" -> new int[] {
                170,
                0,
                0
            };
            case "5" -> new int[] {
                170,
                0,
                170
            };
            case "6" -> new int[] {
                255,
                170,
                0
            };
            case "7" -> new int[] {
                170,
                170,
                170
            };
            case "8" -> new int[] {
                85,
                85,
                85
            };
            case "9" -> new int[] {
                85,
                85,
                255
            };
            case "a" -> new int[] {
                85,
                255,
                85
            };
            case "b" -> new int[] {
                85,
                255,
                255
            };
            case "c" -> new int[] {
                255,
                85,
                85
            };
            case "d" -> new int[] {
                255,
                85,
                255
            };
            case "e" -> new int[] {
                255,
                255,
                85
            };
            default -> new int[] {
                255,
                255,
                255
            };
        };
    }

    public static String codeToHex(String code) {
        String hex = "";
        int[] rgb = codeToRgb(code);
        for (int i: rgb) {
            switch (i) {
                case 0:
                    hex += "00";
                    break;
                case 170:
                    hex += "AA";
                    break;
                case 255:
                    hex += "FF";
                    break;
                case 85:
                    hex += "55";
                    break;
            }
        }

        return hex;
    }

    public final int[] toRgb() {
        return codeToRgb(Code + "");
    }

}