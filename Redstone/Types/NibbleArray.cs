﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.sun.jdi;
using com.sun.org.apache.bcel.@internal.util;

namespace Redstone.Types
{
    /*
 * From MorbZ/J2Blocks, modified for use with Redstone.
* The MIT License (MIT)
* 
* Copyright (c) 2014-2015 Merten Peetz
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
    /// <summary>
    /// An array for nibbles (4-bit values)
    /// </summary>
    internal class NibbleArray
    {
        public NibbleArray(int size)
        {
            Size = size;
            int num = (int) Math.Ceiling(size / 2.0);
            Bytes = new byte[num];
        }

        /// <summary>
        /// Sets an element
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Set(int index, byte value)
        {
            byte data = Bytes[index / 2];
            if (index % 2 == 0)
            {
                data |= (byte) (value & 0xF);
            }
            else
            {
                data |= (byte) ((value & 0xF) << 4);
            }

            Bytes[index / 2] = data;
        }

        /// <summary>
        /// Gets an element
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte Get(int index)
        {
            byte data = Bytes[index / 2];
            if (index % 2 == 0)
            {
                return (byte) (data & 0xF);
            }
            else
            {
                return (byte) ((data >> 4) & 0xF);
            }
        }

        /// <summary>
        /// The number of elements
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Returns the byte array that holds the nibble values.
        /// IN case the size of the nibble array is old, the last bytes wiill only
        /// only hold one available.
        /// </summary>
        public byte[] Bytes { get; }
    }
}
