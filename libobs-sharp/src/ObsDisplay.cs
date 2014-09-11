﻿/***************************************************************************
	Copyright (C) 2014 by Ari Vuollet <ari.vuollet@kapsi.fi>
	
	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, see <http://www.gnu.org/licenses/>.
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS
{
	public class ObsDisplay
	{
		internal unsafe libobs.obs_display* instance;    //pointer to unmanaged object

		public unsafe ObsDisplay(libobs.gs_init_data graphicsData)
		{
			instance = (libobs.obs_display*)libobs.obs_display_create(ref graphicsData);
			if (instance == null)
				throw new ApplicationException("obs_display_create failed");
		}

		public unsafe ObsDisplay(IntPtr ptr)
		{
			instance = (libobs.obs_display*)ptr;
		}

		~ObsDisplay()
		{
			Release();
		}

		public unsafe void Release()
		{
			if (instance == null)
				return;

			libobs.obs_display_destroy((IntPtr)instance);

			instance = null;
		}

		public unsafe libobs.obs_display* GetPointer()
		{
			return instance;
		}
	}
}
