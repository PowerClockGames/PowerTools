﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TipsyTwinStudios.Tools
{	
	/// <summary>
	/// Contains all extension methods of the Corgi Engine and Infinite Runner Engine.
	/// </summary>
	public static class ExtensionMethods 
	{
		/// <summary>
		/// Determines if an animator contains a certain parameter, based on a type and a name
		/// </summary>
		/// <returns><c>true</c> if has parameter of type the specified self name type; otherwise, <c>false</c>.</returns>
		/// <param name="self">Self.</param>
		/// <param name="name">Name.</param>
		/// <param name="type">Type.</param>
		public static bool HasParameterOfType (this Animator self, string name, AnimatorControllerParameterType type) 
		{
			if (name == null || name == "") { return false; }
			AnimatorControllerParameter[] parameters = self.parameters;
			foreach (AnimatorControllerParameter currParam in parameters) 
			{
				if (currParam.type == type && currParam.name == name) 
				{
					return true;
				}
			}
			return false;
        }

        public static bool ContainsParam(this Animator _Anim, string _ParamName)
        {
            foreach (AnimatorControllerParameter param in _Anim.parameters)
            {
                if (param.name == _ParamName) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if a renderer is visible from a camera
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
        {
            Plane[] frustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(frustumPlanes, renderer.bounds);
        }

        /// <summary>
        /// Returns true if this rectangle intersects the other specified rectangle
        /// </summary>
        /// <param name="thisRectangle"></param>
        /// <param name="otherRectangle"></param>
        /// <returns></returns>
        public static bool Intersects(this Rect thisRectangle, Rect otherRectangle)
        {
            return !((thisRectangle.x > otherRectangle.xMax) || (thisRectangle.xMax < otherRectangle.x) || (thisRectangle.y > otherRectangle.yMax) || (thisRectangle.yMax < otherRectangle.y));
        }

        /// <summary>
        /// Returns bool if layer is within layermask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool Contains(this LayerMask mask, int layer) 
        {
             return ((mask.value & (1 << layer)) > 0);
        }
         
        /// <summary>
        /// Returns true if gameObject is within layermask
        /// </summary>
        /// <param name="mask"></param>
        /// <param name="gameobject"></param>
        /// <returns></returns>
		public static bool Contains(this LayerMask mask, GameObject gameobject) 
        {
             return ((mask.value & (1 << gameobject.layer)) > 0);
        }

		static List<Component> m_ComponentCache = new List<Component>();

        /// <summary>
        /// Grabs a component without allocating memory uselessly
        /// </summary>
        /// <param name="this"></param>
        /// <param name="componentType"></param>
        /// <returns></returns>
		public static Component GetComponentNoAlloc(this GameObject @this, System.Type componentType) 
		{ 
			@this.GetComponents(componentType, m_ComponentCache); 
			var component = m_ComponentCache.Count > 0 ? m_ComponentCache[0] : null; 
			m_ComponentCache.Clear(); 
			return component; 
		} 

        /// <summary>
        /// Grabs a component without allocating memory uselessly
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
		public static T GetComponentNoAlloc<T>(this GameObject @this) where T : Component
		{
			@this.GetComponents(typeof(T), m_ComponentCache);
			var component = m_ComponentCache.Count > 0 ? m_ComponentCache[0] : null;
			m_ComponentCache.Clear();
			return component as T;
		}

        /// <summary>
        /// Rotates a vector2 by angleInDegrees
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="angleInDegrees"></param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 vector, float angleInDegrees)
        {
            float sin = Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);
            float tx = vector.x;
            float ty = vector.y;
            vector.x = (cos * tx) - (sin * ty);
            vector.y = (sin * tx) + (cos * ty);
            return vector;
        }


        /// <summary>
        /// Normalizes an angle in degrees
        /// </summary>
        /// <param name="angleInDegrees"></param>
        /// <returns></returns>
        public static float NormalizeAngle(this float angleInDegrees)
        {
            angleInDegrees = angleInDegrees % 360f;
            if (angleInDegrees < 0)
            {
                angleInDegrees += 360f;
            }                
            return angleInDegrees;
        }


    }
}