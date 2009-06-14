/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#if defined(HAVE_NCURSESW_NCURSES_H)
#include <ncursesw/ncurses.h>
#elif defined(HAVE_NCURSES_H)
#include <ncurses.h>
#else
#include <curses.h>
#endif

#include <stdio.h>


#define GEN_ATTR(x) fprintf(OUT, "\t\tpublic const uint " #x " = 0x%.8lxU;\n", (A_ ## x))
#define GEN_ACS(x) fprintf(OUT, "\t\tpublic const uint " #x " = 0x%.8lxU;\n", (ACS_ ## x))
#define GEN_COLOR(x) fprintf(OUT, "\t\tpublic const short " #x " = 0x%x;\n", (COLOR_ ## x))
#define GEN_KEY(x) fprintf(OUT, "\t\tpublic const int " #x " = 0x%.3x;\n", (KEY_ ## x))
#define GEN_MMASK(x) fprintf(OUT, "\t\tpublic const uint " #x " = 0x%.8lxU;\n", (x))

int main(int argc, char **argv)
{
	FILE* OUT;

	if (argc < 2)
		return -1;
	OUT = fopen(argv[1], "wt");
	if (!OUT)
		return -1;

#ifndef WIN32
	initscr();
#endif

	fprintf(OUT, "// File generated by attrgen\n");
	fprintf(OUT, "\n");

	fprintf(OUT, "namespace CursesSharp\n");
	fprintf(OUT, "{\n");

	fprintf(OUT, "\t// Character attributes\n");
	fprintf(OUT, "\tpublic static class Attrs\n");
	fprintf(OUT, "\t{\n");
	GEN_ATTR(NORMAL);
	GEN_ATTR(ALTCHARSET);
	GEN_ATTR(BLINK);
	GEN_ATTR(BOLD);
	GEN_ATTR(DIM);
	GEN_ATTR(INVIS);
	GEN_ATTR(PROTECT);
	GEN_ATTR(REVERSE);
	GEN_ATTR(STANDOUT);
	GEN_ATTR(UNDERLINE);
	fprintf(OUT, "\t\t// Attribute masks\n");
	GEN_ATTR(ATTRIBUTES);
	GEN_ATTR(CHARTEXT);
	GEN_ATTR(COLOR);
	fprintf(OUT, "\t}\n");

	fprintf(OUT, "\n");

	fprintf(OUT, "\t// Line drawing characters\n");
	fprintf(OUT, "\tpublic static class Acs\n");
	fprintf(OUT, "\t{\n");
	GEN_ACS(BLOCK);
	GEN_ACS(BOARD);
	GEN_ACS(BTEE);
	GEN_ACS(BULLET);
	GEN_ACS(CKBOARD);
	GEN_ACS(DARROW);
	GEN_ACS(DEGREE);
	GEN_ACS(DIAMOND);
	GEN_ACS(GEQUAL);
	GEN_ACS(HLINE);
	GEN_ACS(LANTERN);
	GEN_ACS(LARROW);
	GEN_ACS(LEQUAL);
	GEN_ACS(LLCORNER);
	GEN_ACS(LRCORNER);
	GEN_ACS(LTEE);
	GEN_ACS(NEQUAL);
	GEN_ACS(PI);
	GEN_ACS(PLMINUS);
	GEN_ACS(PLUS);
	GEN_ACS(RARROW);
	GEN_ACS(RTEE);
	GEN_ACS(S1);
	GEN_ACS(S3);
	GEN_ACS(S7);
	GEN_ACS(S9);
	GEN_ACS(STERLING);
	GEN_ACS(TTEE);
	GEN_ACS(UARROW);
	GEN_ACS(ULCORNER);
	GEN_ACS(URCORNER);
	GEN_ACS(VLINE);
	fprintf(OUT, "\t}\n");

	fprintf(OUT, "\n");

	fprintf(OUT, "\t// Colors\n");
	fprintf(OUT, "\tpublic static class Colors\n");
	fprintf(OUT, "\t{\n");
	GEN_COLOR(BLACK);
	GEN_COLOR(BLUE);
	GEN_COLOR(GREEN);
	GEN_COLOR(CYAN);
	GEN_COLOR(RED);
	GEN_COLOR(MAGENTA);
	GEN_COLOR(YELLOW);
	GEN_COLOR(WHITE);
	fprintf(OUT, "\t}\n");

	fprintf(OUT, "\n");

	fprintf(OUT, "\t// Keys\n");
	fprintf(OUT, "\tpublic static class Keys\n");
	fprintf(OUT, "\t{\n");
	GEN_KEY(BREAK);
	GEN_KEY(DOWN);
	GEN_KEY(UP);
	GEN_KEY(LEFT);
	GEN_KEY(RIGHT);
	GEN_KEY(HOME);
	GEN_KEY(BACKSPACE);
	GEN_KEY(F0);
	GEN_KEY(DL);
	GEN_KEY(IL);
	GEN_KEY(DC);
	GEN_KEY(IC);
	GEN_KEY(EIC);
	GEN_KEY(CLEAR);
	GEN_KEY(EOS);
	GEN_KEY(EOL);
	GEN_KEY(SF);
	GEN_KEY(SR);
	GEN_KEY(NPAGE);
	GEN_KEY(PPAGE);
	GEN_KEY(STAB);
	GEN_KEY(CTAB);
	GEN_KEY(CATAB);
	GEN_KEY(ENTER);
	GEN_KEY(SRESET);
	GEN_KEY(RESET);
	GEN_KEY(PRINT);
	GEN_KEY(LL);
	GEN_KEY(A1);
	GEN_KEY(A3);
	GEN_KEY(B2);
	GEN_KEY(C1);
	GEN_KEY(C3);
	GEN_KEY(BTAB);
	GEN_KEY(BEG);
	GEN_KEY(CANCEL);
	GEN_KEY(CLOSE);
	GEN_KEY(COMMAND);
	GEN_KEY(COPY);
	GEN_KEY(CREATE);
	GEN_KEY(END);
	GEN_KEY(EXIT);
	GEN_KEY(FIND);
	GEN_KEY(HELP);
	GEN_KEY(MARK);
	GEN_KEY(MESSAGE);
	GEN_KEY(MOUSE);
	GEN_KEY(MOVE);
	GEN_KEY(NEXT);
	GEN_KEY(OPEN);
	GEN_KEY(OPTIONS);
	GEN_KEY(PREVIOUS);
	GEN_KEY(REDO);
	GEN_KEY(REFERENCE);
	GEN_KEY(REFRESH);
	GEN_KEY(REPLACE);
	GEN_KEY(RESIZE);
	GEN_KEY(RESTART);
	GEN_KEY(RESUME);
	GEN_KEY(SAVE);
	GEN_KEY(SBEG);
	GEN_KEY(SCANCEL);
	GEN_KEY(SCOMMAND);
	GEN_KEY(SCOPY);
	GEN_KEY(SCREATE);
	GEN_KEY(SDC);
	GEN_KEY(SDL);
	GEN_KEY(SELECT);
	GEN_KEY(SEND);
	GEN_KEY(SEOL);
	GEN_KEY(SEXIT);
	GEN_KEY(SFIND);
	GEN_KEY(SHELP);
	GEN_KEY(SHOME);
	GEN_KEY(SIC);
	GEN_KEY(SLEFT);
	GEN_KEY(SMESSAGE);
	GEN_KEY(SMOVE);
	GEN_KEY(SNEXT);
	GEN_KEY(SOPTIONS);
	GEN_KEY(SPREVIOUS);
	GEN_KEY(SPRINT);
	GEN_KEY(SREDO);
	GEN_KEY(SREPLACE);
	GEN_KEY(SRIGHT);
	GEN_KEY(SRSUME);
	GEN_KEY(SSAVE);
	GEN_KEY(SSUSPEND);
	GEN_KEY(SUNDO);
	GEN_KEY(SUSPEND);
	GEN_KEY(UNDO);
	fprintf(OUT, "\n");
	fprintf(OUT, "\t\tpublic static int KEY_F(int n)\n");
	fprintf(OUT, "\t\t{\n");
	fprintf(OUT, "\t\t\treturn Keys.F0 + n;\n");
	fprintf(OUT, "\t\t}\n");
	fprintf(OUT, "\n");
	GEN_KEY(MIN);
	GEN_KEY(MAX);
	fprintf(OUT, "\t}\n");

	fprintf(OUT, "\n");

	fprintf(OUT, "\t// Mouse event masks\n");
	fprintf(OUT, "\tpublic static class Mouse\n");
	fprintf(OUT, "\t{\n");
	GEN_MMASK(BUTTON1_PRESSED);
	GEN_MMASK(BUTTON1_RELEASED);
	GEN_MMASK(BUTTON1_CLICKED);
	GEN_MMASK(BUTTON1_DOUBLE_CLICKED);
	GEN_MMASK(BUTTON1_TRIPLE_CLICKED);
	GEN_MMASK(BUTTON2_PRESSED);
	GEN_MMASK(BUTTON2_RELEASED);
	GEN_MMASK(BUTTON2_CLICKED);
	GEN_MMASK(BUTTON2_DOUBLE_CLICKED);
	GEN_MMASK(BUTTON2_TRIPLE_CLICKED);
	GEN_MMASK(BUTTON3_PRESSED);
	GEN_MMASK(BUTTON3_RELEASED);
	GEN_MMASK(BUTTON3_CLICKED);
	GEN_MMASK(BUTTON3_DOUBLE_CLICKED);
	GEN_MMASK(BUTTON3_TRIPLE_CLICKED);
	GEN_MMASK(BUTTON4_PRESSED);
	GEN_MMASK(BUTTON4_RELEASED);
	GEN_MMASK(BUTTON4_CLICKED);
	GEN_MMASK(BUTTON4_DOUBLE_CLICKED);
	GEN_MMASK(BUTTON4_TRIPLE_CLICKED);
	GEN_MMASK(BUTTON_SHIFT);
	GEN_MMASK(BUTTON_CTRL);
	GEN_MMASK(BUTTON_ALT);
	GEN_MMASK(ALL_MOUSE_EVENTS);
	GEN_MMASK(REPORT_MOUSE_POSITION);
	fprintf(OUT, "\t}\n");

	fprintf(OUT, "}\n");

#ifndef WIN32
	endwin();
#endif

	fclose(OUT);

	return 0;
}
