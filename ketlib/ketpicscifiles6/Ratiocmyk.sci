// 11.05.28
// 15.05.03

function R=Ratiocmyk(Color)
  if type(Color)==1 then
    R=Color;
    return;
  end;
  Tmp=grep(Color,',');
  if length(Tmp)>0
    R=evstr(Tmp);
    return;
  end;
  select Color
    case 'greenyellow' then R=[0.15,0,0.69,0],
    case 'yellow' then R=[0,0,1,0],
    case 'goldenrod' then R=[0,0.1,0.84,0],
    case 'dandelion' then R=[0,0.29,0.84,0],
    case 'apricot' then R=[0,0.32,0.52,0],
    case 'peach' then R=[0,0.5,0.7,0],
    case 'melon' then R=[0,0.46,0.5,0],
    case 'yelloworange' then R=[0,0.42,1,0],
    case 'orange' then R=[0,0.61,0.87,0],
    case 'burntorange' then R=[0,0.51,1,0],
    case 'bittersweet' then R=[0,0.75,1,0.24],
    case 'redorange' then R=[0,0.77,0.87,0],
    case 'mahogany' then R=[0,0.85,0.87,0.35],
    case 'maroon' then R=[0,0.87,0.68,0.32],
    case 'brickred' then R=[0,0.89,0.94,0.28],
    case 'red' then R=[0,1,1,0],
    case 'orangered' then R=[0,1,0.5,0],
    case 'rubinered' then R=[0,1,0.13,0],
    case 'wildstrawberry' then R=[0,0.96,0.39,0],
    case 'salmon' then R=[0,0.53,0.38,0],
    case 'carnationpink' then R=[0,0.63,0,0],
    case 'magenta' then R=[0,1,0,0],
    case 'violetred' then R=[0,0.81,0,0],
    case 'rhodamine' then R=[0,0.82,0,0],
    case 'mulberry' then R=[0.34,0.9,0,0.02],
    case 'redviolet' then R=[0.07,0.9,0,0.34],
    case 'fuchsia' then R=[0.47,0.91,0,0.08],
    case 'lavender' then R=[0,0.48,0,0],
    case 'thistle' then R=[0.12,0.59,0,0],
    case 'orchid' then R=[0.32,0.64,0,0],
    case 'darkorchid' then R=[0.4,0.8,0.2,0],
    case 'purple' then R=[0.45,0.86,0,0],
    case 'plum' then R=[0.5,1,0,0],
    case 'violet' then R=[0.79,0.88,0,0],
    case 'royalpurple' then R=[0.75,0.9,0,0],
    case 'blueviolet' then R=[0.86,0.91,0,0.04],
    case 'periwinkle' then R=[0.57,0.55,0,0],
    case 'cadetblue' then R=[0.62,0.57,0.23,0],
    case 'cornflowerblue' then R=[0.65,0.13,0,0],
    case 'midnightblue' then R=[0.98,0.13,0,0.43],
    case 'navyblue' then R=[0.94,0.54,0,0],
    case 'royalblue' then R=[1,0.5,0,0],
    case 'blue' then R=[1,1,0,0],
    case 'cerulean' then R=[0.94,0.11,0,0],
    case 'cyan' then R=[1,0,0,0],
    case 'processblue' then R=[0.96,0,0,0],
    case 'skyblue' then R=[0.62,0,0.12,0],
    case 'turquoise' then R=[0.85,0,0.2,0],
    case 'tealblue' then R=[0.86,0,0.34,0.02],
    case 'aquamarine' then R=[0.82,0,0.3,0],
    case 'bluegreen' then R=[0.85,0,0.33,0],
    case 'emerald' then R=[1,0,0.5,0],
    case 'junglegreen' then R=[0.99,0,0.52,0],
    case 'seagreen' then R=[0.69,0,0.5,0],
    case 'green' then R=[1,0,1,0],
    case 'forestgreen' then R=[0.91,0,0.88,0.12],
    case 'pinegreen' then R=[0.92,0,0.59,0.25],
    case 'limegreen' then R=[0.5,0,1,0],
    case 'yellowgreen' then R=[0.44,0,0.74,0],
    case 'springgreen' then R=[0.26,0,0.76,0],
    case 'olivegreen' then R=[0.64,0,0.95,0.4],
    case 'rawsienna' then R=[0,0.72,1,0.45],
    case 'sepia' then R=[0,0.83,1,0.7],
    case 'brown' then R=[0,0.81,1,0.6],
    case 'tan' then R=[0.14,0.42,0.56,0],
    case 'gray' then R=[0,0,0,0.5],
    case 'black' then R=[0,0,0,1],
    case 'white' then R=[0,0,0,0],
    else 
      disp(Color+' may be user-defined');
      R=Color;  // 15.05.03
  end;
endfunction;
