﻿using System.Collections.Generic;

namespace Dialogue
{
    public abstract class CompositeNode : Node
    {
        // 有多个子节点构成的列表
        public List<Node> children = new List<Node>();
    }
}