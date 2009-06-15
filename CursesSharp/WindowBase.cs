#region Copyright 2009 Robert Konklewski

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

#endregion

using System;
using System.Text;

namespace CursesSharp
{
    public abstract class WindowBase: IDisposable
    {
        internal const int DEFAULT_BUFSZ = 1023;

        private IntPtr winptr;
        private bool ownsPtr;

        protected internal WindowBase(IntPtr winptr, bool ownsPtr)
        {
            this.winptr = winptr;
            this.ownsPtr = ownsPtr;
        }

        protected internal IntPtr Handle
        {
            get { return this.winptr; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.winptr != IntPtr.Zero && this.ownsPtr)
            {
                CursesMethods.delwin(this.winptr);
                this.winptr = IntPtr.Zero;
            }
        }

        #endregion

        public void AddCh(char ch)
        {
            CursesMethods.waddch(this.winptr, (byte)ch);
        }

        public void AddCh(uint ch)
        {
            CursesMethods.waddch(this.winptr, ch);
        }

        public void AddCh(int y, int x, char ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, (byte)ch);
        }

        public void AddCh(int y, int x, uint ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, ch);
        }

        public virtual void EchoChar(char ch)
        {
            CursesMethods.wechochar(this.winptr, (byte)ch);
        }

        public virtual void EchoChar(uint ch)
        {
            CursesMethods.wechochar(this.winptr, ch);
        }

        public void AddChStr(uint[] chstr)
        {
            this.AddChStr(chstr, chstr.Length);
        }

        public void AddChStr(uint[] chstr, int n)
        {
            CursesMethods.waddchnstr(this.winptr, chstr, n);
        }

        public void AddChStr(int y, int x, uint[] chstr)
        {
            this.AddChStr(y, x, chstr, chstr.Length);
        }

        public void AddChStr(int y, int x, uint[] chstr, int n)
        {
            CursesMethods.mvwaddchnstr(this.winptr, y, x, chstr, n);
        }

        public void AddStr(string str)
        {
            this.AddStr(str, str.Length);
        }

        public void AddStr(string str, int n)
        {
            CursesMethods.waddnstr(this.winptr, str, n);
        }

        public void AddStr(int y, int x, string str)
        {
            this.AddStr(y, x, str, str.Length);
        }

        public void AddStr(int y, int x, string str, int n)
        {
            CursesMethods.mvwaddnstr(this.winptr, y, x, str, n);
        }

        public uint Attr
        {
            get
            {
                uint attrs;
                short color_pair;
                CursesMethods.wattr_get(this.winptr, out attrs, out color_pair);
                return attrs;
            }
            set
            {
                CursesMethods.wattrset(this.winptr, value);
            }
        }

        public void AttrOff(uint attr)
        {
            CursesMethods.wattroff(this.winptr, attr);
        }

        public void AttrOn(uint attr)
        {
            CursesMethods.wattron(this.winptr, attr);
        }

        public void Standend()
        {
            CursesMethods.wstandend(this.winptr);
        }

        public void Standout()
        {
            CursesMethods.wstandout(this.winptr);
        }

        public short Color
        {
            get
            {
                uint attrs;
                short color_pair;
                CursesMethods.wattr_get(this.winptr, out attrs, out color_pair);
                return color_pair;
            }
            set
            {
                CursesMethods.wcolor_set(this.winptr, value);
            }
        }

        public void ChangeAttr(int n, uint attr, short color)
        {
            CursesMethods.wchgat(this.winptr, n, attr, color);
        }

        public void ChangeAttr(int y, int x, int n, uint attr, short color)
        {
            CursesMethods.mvwchgat(this.winptr, y, x, n, attr, color);
        }

        public uint Background
        {
            get { return CursesMethods.getbkgd(this.winptr); }
            set { CursesMethods.wbkgd(this.winptr, value); }
        }

        public void FillBackground(uint ch)
        {
            CursesMethods.wbkgdset(this.winptr, ch);
        }

        public void Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            CursesMethods.wborder(this.winptr, ls, rs, ts, bs, tl, tr, bl, br);
        }

        public void Box(uint verch, uint horch)
        {
            CursesMethods.box(this.winptr, verch, horch);
        }

        public void HLine(uint ch, int n)
        {
            CursesMethods.whline(this.winptr, ch, n);
        }

        public void VLine(uint ch, int n)
        {
            CursesMethods.wvline(this.winptr, ch, n);
        }

        public void HLine(int y, int x, uint ch, int n)
        {
            CursesMethods.mvwhline(this.winptr, y, x, ch, n);
        }

        public void VLine(int y, int x, uint ch, int n)
        {
            CursesMethods.mvwvline(this.winptr, y, x, ch, n);
        }

        public void Clear()
        {
            CursesMethods.wclear(this.winptr);
        }

        public void Erase()
        {
            CursesMethods.werase(this.winptr);
        }

        public void ClearToBottom()
        {
            CursesMethods.wclrtobot(this.winptr);
        }

        public void ClearToEol()
        {
            CursesMethods.wclrtoeol(this.winptr);
        }

        public void DelCh()
        {
            CursesMethods.wdelch(this.winptr);
        }

        public void DelCh(int y, int x)
        {
            CursesMethods.mvwdelch(this.winptr, y, x);
        }

        public void DeleteLn()
        {
            CursesMethods.wdeleteln(this.winptr);
        }

        public void InsDelLn(int n)
        {
            CursesMethods.winsdelln(this.winptr, n);
        }

        public void InsertLn()
        {
            CursesMethods.winsertln(this.winptr);
        }

        public int GetCh()
        {
            return CursesMethods.wgetch(this.winptr);
        }

        public int GetCh(int y, int x)
        {
            return CursesMethods.mvwgetch(this.winptr, y, x);
        }

        public string GetStr()
        {
            return this.GetStr(DEFAULT_BUFSZ);
        }

        public string GetStr(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            CursesMethods.wgetnstr(this.winptr, sb, n);
            return sb.ToString();
        }

        public string GetStr(int y, int x)
        {
            return this.GetStr(y, x, DEFAULT_BUFSZ);
        }

        public string GetStr(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            CursesMethods.mvwgetnstr(this.winptr, y, x, sb, n);
            return sb.ToString();
        }

        public void GetYX(out int y, out int x)
        {
            CursesMethods.getyx(this.winptr, out y, out x);
        }

        public void GetParYX(out int y, out int x)
        {
            CursesMethods.getparyx(this.winptr, out y, out x);
        }

        public void GetBegYX(out int y, out int x)
        {
            CursesMethods.getbegyx(this.winptr, out y, out x);
        }

        public void GetMaxYX(out int y, out int x)
        {
            CursesMethods.getmaxyx(this.winptr, out y, out x);
        }

        public uint InCh()
        {
            return CursesMethods.winch(this.winptr);
        }

        public uint InCh(int y, int x)
        {
            return CursesMethods.mvwinch(this.winptr, y, x);
        }

        public uint[] InChStr(int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.winchnstr(this.winptr, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public uint[] InChStr(int y, int x, int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.mvwinchnstr(this.winptr, y, x, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public void InsCh(char ch)
        {
            CursesMethods.winsch(this.winptr, (byte)ch);
        }

        public void InsCh(uint ch)
        {
            CursesMethods.winsch(this.winptr, ch);
        }

        public void InsCh(int y, int x, char ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, (byte)ch);
        }

        public void InsCh(int y, int x, uint ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, ch);
        }

        public void InsStr(string str)
        {
            this.InsStr(str, str.Length);
        }

        public void InsStr(string str, int n)
        {
            CursesMethods.winsnstr(this.winptr, str, n);
        }

        public void InsStr(int y, int x, string str)
        {
            this.InsStr(y, x, str, str.Length);
        }

        public void InsStr(int y, int x, string str, int n)
        {
            CursesMethods.mvwinsnstr(this.winptr, y, x, str, n);
        }

        public string InStr(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = CursesMethods.winnstr(this.winptr, sb, n);
            return sb.ToString(0, nOut);
        }

        public string InStr(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = CursesMethods.mvwinnstr(this.winptr, y, x, sb, n);
            return sb.ToString(0, nOut);
        }

        public bool FlushOnInterrupt
        {
            set
            {
                CursesMethods.intrflush(this.winptr, value);
            }
        }

        public bool UseKeypad
        {
            set
            {
                CursesMethods.keypad(this.winptr, value);
            }
        }

        public bool UseMeta
        {
            set
            {
                CursesMethods.meta(this.winptr, value);
            }
        }

        public bool IsBlocking
        {
            set
            {
                CursesMethods.nodelay(this.winptr, !value);
            }
        }

        public int BlockTimeout
        {
            set
            {
                CursesMethods.wtimeout(this.winptr, value);
            }
        }

        public bool WaitOnEscape
        {
            set
            {
                CursesMethods.notimeout(this.winptr, !value);
            }
        }

        public bool Enclose(int y, int x)
        {
            return CursesMethods.wenclose(this.winptr, y, x);
        }

        public bool MouseTrafo(ref int y, ref int x, bool to_screen)
        {
            return CursesMethods.wmouse_trafo(this.winptr, ref y, ref x, to_screen);
        }

        public void Move(int y, int x)
        {
            CursesMethods.wmove(this.winptr, y, x);
        }

        public bool ClearOnRefresh
        {
            set
            {
                CursesMethods.clearok(this.winptr, value);
            }
        }

        public bool UseHwInsDelLine
        {
            set
            {
                CursesMethods.idlok(this.winptr, value);
            }
        }

        public bool UseHwInsDelChar
        {
            set
            {
                CursesMethods.idcok(this.winptr, value);
            }
        }

        public bool ImmediateRefresh
        {
            set
            {
                CursesMethods.immedok(this.winptr, value);
            }
        }

        public bool CanLeaveCursor
        {
            set
            {
                CursesMethods.leaveok(this.winptr, value);
            }
        }

        public bool CanScroll
        {
            set
            {
                CursesMethods.scrollok(this.winptr, value);
            }
        }

        public void SetScrollRegion(int top, int bot)
        {
            CursesMethods.wsetscrreg(this.winptr, top, bot);
        }

        public void Overlay(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void Overwrite(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void Copy(WindowBase dstWin, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            CursesMethods.copywin(this.winptr, dstWin.winptr, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
        }

        public void Redraw()
        {
            CursesMethods.redrawwin(this.winptr);
        }

        public void Redraw(int beg_line, int num_lines)
        {
            CursesMethods.wredrawln(this.winptr, beg_line, num_lines);
        }

        public void Scroll()
        {
            CursesMethods.scroll(this.winptr);
        }

        public void Scroll(int n)
        {
            CursesMethods.wscrl(this.winptr, n);
        }

        public void Touch()
        {
            CursesMethods.touchwin(this.winptr);
        }

        public void Touch(int start, int count)
        {
            CursesMethods.touchline(this.winptr, start, count);
        }

        public void Touch(int y, int n, int changed)
        {
            CursesMethods.wtouchln(this.winptr, y, n, changed);
        }

        public void Untouch()
        {
            CursesMethods.untouchwin(this.winptr);
        }

        public bool IsTouched(int line)
        {
            return CursesMethods.is_linetouched(this.winptr, line);
        }

        public bool IsTouched()
        {
            return CursesMethods.is_wintouched(this.winptr);
        }

        public void MoveWin(int y, int x)
        {
            CursesMethods.mvwin(this.winptr, y, x);
        }

        public void MoveDerWin(int pary, int parx)
        {
            CursesMethods.mvderwin(this.winptr, pary, parx);
        }

        public bool ImmediateSyncUp
        {
            set
            {
                CursesMethods.syncok(this.winptr, value);
            }
        }

        public void SyncUp()
        {
            CursesMethods.wsyncup(this.winptr);
        }

        public void SyncDown()
        {
            CursesMethods.wsyncdown(this.winptr);
        }

        public void CurSyncUp()
        {
            CursesMethods.wcursyncup(this.winptr);
        }
    }
}
