// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-09-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="Resources.Designer.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace SergioDelgadoProyecto.Properties {
    using System;


    /// <summary>
    /// Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {

        /// <summary>
        /// The resource man
        /// </summary>
        private static global::System.Resources.ResourceManager resourceMan;

        /// <summary>
        /// The resource culture
        /// </summary>
        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }

        /// <summary>
        /// Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        /// <value>The resource manager.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SergioDelgadoProyecto.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        /// búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        /// <value>The culture.</value>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
    }
}
